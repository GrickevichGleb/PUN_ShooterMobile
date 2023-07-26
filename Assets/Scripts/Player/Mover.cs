using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2f;

        private PhotonView _photonView;
        
        private PlayerControls _playerControls;
        private Vector2 _moveInput;
        private Vector2 _lookInput;

        private void Start()
        {
            // Enabling control scheme 
            _playerControls = new PlayerControls();
            _playerControls.Enable();
            
            _photonView = GetComponent<PlayerController>().GetPhotonView();
        }


        private void Update()
        {
            if (!_photonView.IsMine) return;
            
            GetInputs();
            MovePlayer();
            RotatePlayer();
        }

        private void MovePlayer()
        {
            if (_moveInput == Vector2.zero) return;
            
            transform.Translate(
                _moveInput.normalized * (moveSpeed * Time.deltaTime)
            );
        }

        private void RotatePlayer()
        {
            if (_lookInput == Vector2.zero) return;

            transform.up =
                Vector2.Lerp(transform.up, _lookInput, 1f);
        }

        private void GetInputs()
        {
            _moveInput = _playerControls.Player.Move.ReadValue<Vector2>();
            _lookInput = _playerControls.Player.Look.ReadValue<Vector2>();
        }
    }
}
