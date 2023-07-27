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

        private Vector2 _prevLookInput;

        private void Start()
        {
            // // Enabling control scheme 
            // _playerControls = new PlayerControls();
            // _playerControls.Enable();
            //
            // _photonView = GetComponent<PlayerController>().GetPhotonView();
        }


        // private void Update()
        // {
        //     if (!_photonView.IsMine) return;
        //     
        //     GetInputs();
        //     //MovePlayer();
        //     RotatePlayer();
        // }

        public void MovePlayer(Vector2 moveInput)
        {
            //if (_moveInput == Vector2.zero) return;
            
            transform.Translate(
                moveInput.normalized * (moveSpeed * Time.deltaTime),
                Space.World
            );
        }

        public void RotatePlayer(Vector2 lookInput)
        {
            //if (_lookInput == Vector2.zero) return;
        
            transform.up =
                Vector2.Lerp(transform.up, lookInput.normalized, 1f);
        }

        // private void GetInputs()
        // {
        //     _moveInput = _playerControls.Player.Move.ReadValue<Vector2>();
        //     _lookInput = _playerControls.Player.Look.ReadValue<Vector2>();
        // }
    }
}
