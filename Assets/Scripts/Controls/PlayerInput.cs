using Player;
using UnityEngine;

namespace Controls
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerController _playerController;
        
        // Input variables
        private PlayerControls _playerControls;
        private Vector2 _moveInput;
        private Vector2 _lookInput;
        
        // State variables
        private Vector2 _prevLookInput;
        private bool _isAiming;
        private bool _isFiring;

        // Component references 
        private Mover _playerMover;
        private Fighter _playerFighter;
        
        // Start is called before the first frame update
        void Start()
        {
            // Enabling control scheme 
            _playerControls = new PlayerControls();
            _playerControls.Enable();
            
            // Getting reference to main PlayerController component
            _playerController = GetComponent<PlayerController>();
            // and to Mover and Fighter components
            _playerMover = _playerController.GetMover();
            _playerFighter = _playerController.GetFighter();
        }

        // Update is called once per frame
        void Update()
        {
            // First check if it's our own player 
            if (!_playerController.GetPhotonView().IsMine) return;
            
            GetInputs();
            ProcessLeftJoyInp();
            ProcessRightJoyInp();
        }


        // Processing left joystick
        private void ProcessLeftJoyInp()
        {
            if (_moveInput == Vector2.zero)
                return;
            
            _playerMover.MovePlayer(_moveInput);
        }


        // Processing right joystick input
        private void ProcessRightJoyInp()
        {
            if (_lookInput == Vector2.zero && _prevLookInput == Vector2.zero)
                return;
            if (_prevLookInput == Vector2.zero && _lookInput != Vector2.zero)
            {
                _isAiming = true;
            }
            if (_prevLookInput != Vector2.zero && _lookInput == Vector2.zero)
            {
                _isFiring = true;
                _isAiming = false;
                
                _playerFighter.Fire();
            }
            
            // Rotate to aim direction
            if(_isAiming)
                _playerMover.RotatePlayer(_lookInput);

            // Updating previous value to check in next frame
            _prevLookInput = _lookInput;
        }
        
        
        // Reads input from joysticks 
        private void GetInputs()
        {
            _moveInput = _playerControls.Player.Move.ReadValue<Vector2>();
            _lookInput = _playerControls.Player.Look.ReadValue<Vector2>();
        }
    }
}
