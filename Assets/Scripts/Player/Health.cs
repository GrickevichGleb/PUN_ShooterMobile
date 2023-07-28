using System;
using Networking;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Health : MonoBehaviourPunCallbacks, IPunObservable
    {
        [SerializeField] private int startHealth = 100;
        
        private PlayerController _playerController;
        private int _currentHealth;

        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _currentHealth = startHealth;
        }


        private void Update()
        {
            CheckCurrentHealth();
        }

        // IPunObservable implementation
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                // We own this player: send the others our data
                stream.SendNext(_currentHealth);
            }
            else
            {
                // Network player, receive data
                this._currentHealth = (int)stream.ReceiveNext();
            }
        }


        // Interface for changing _currentHealth
        public void TakeDamage(int damage)
        {
            // Health can't be negative 
            _currentHealth = Mathf.Max(0, _currentHealth - damage);
        }

        
        // Interface for getting health params 
        public int GetCurrentHealth()
        {
            return _currentHealth;
        }


        public int GetMaxHealth()
        {
            return startHealth;
        }


        // Check if health is 0 (means we've lost)
        private void CheckCurrentHealth()
        {
            if (!_playerController.GetPhotonView().IsMine) return;

            if (_currentHealth == 0)
            {
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene(0);
            }
        }
    }
}
