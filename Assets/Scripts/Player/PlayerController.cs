using System;
using Networking;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviourPunCallbacks
    {
        public bool isGameOver { get; private set; }

        private Joystick _leftJoystick;
        private Joystick _rightJoystick;

        private PhotonView _photonView;

        private Mover _playerMover;
        private Health _playerHealth;
        private Fighter _playerFighter;
        private String _nickName;
        
        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
            _playerMover = GetComponent<Mover>();
            _playerHealth = GetComponent<Health>();
            _playerFighter = GetComponent<Fighter>();

            PhotonNetwork.NickName = "Player " + PhotonNetwork.PlayerList.Length;
            
            Debug.Log(PhotonNetwork.NickName);
        }

        private void Start()
        {
            FindObjectOfType<GameController>().OnGameOver += OnGameOverHandler;
        }

        public override void OnLeftRoom()
        {
            FindObjectOfType<GameController>().OnGameOver -= OnGameOverHandler;
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


        public String GetNickName()
        {
            return _photonView.Owner.NickName;
        }
        

        private void OnGameOverHandler()
        {
            isGameOver = true;
        }

        
    }
}
