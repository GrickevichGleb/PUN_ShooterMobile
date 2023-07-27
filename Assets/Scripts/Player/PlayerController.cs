using System;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Joystick _leftJoystick;
        private Joystick _rightJoystick;

        private PhotonView _photonView;

        private Mover _playerMover;
        private Health _playerHealth;
        private Fighter _playerFighter;
        
        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
            _playerMover = GetComponent<Mover>();
            _playerHealth = GetComponent<Health>();
            _playerFighter = GetComponent<Fighter>();
        }
        

        // For easier access to PhotonView from other components
        public PhotonView GetPhotonView()
        {
            return _photonView;
        }

    }
}
