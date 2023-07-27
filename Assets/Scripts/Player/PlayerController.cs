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
        

        // Allows easier access for components to each other 
        public PhotonView GetPhotonView()
        {
            return _photonView;
        }

        public Mover GetMover()
        {
            return _playerMover;
        }


        public Fighter GetFighter()
        {
            return _playerFighter;
        }

    }
}
