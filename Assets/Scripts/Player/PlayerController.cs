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
    
        // Start is called before the first frame update
        void Start()
        {
            _photonView = GetComponent<PhotonView>();
            _playerMover = GetComponent<Mover>();
            _playerHealth = GetComponent<Health>();
            _playerFighter = GetComponent<Fighter>();
        }

        // Update is called once per frame
        void Update()
        {
            //UpdateMove();
        }

        // For easier access to PhotonView from other components
        public PhotonView GetPhotonView()
        {
            return _photonView;
        }

    }
}
