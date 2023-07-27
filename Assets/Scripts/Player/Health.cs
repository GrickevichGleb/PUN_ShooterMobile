using System;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class Health : MonoBehaviourPunCallbacks, IPunObservable
    {
        [SerializeField] private int startHealth = 100;
    
        public int _currentHealth;

        private PlayerController _playerController;
        
        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _currentHealth = startHealth;
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


        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("OnTriggerEnter2D");
            if (!_playerController.GetPhotonView().IsMine)
                return;

            if (other.TryGetComponent<Fighter>(out Fighter fighter))
            {
                TakeDamage(fighter.GetDamageVal());
            }
        }


        // Interface for changing _currentHealth
        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - damage);
        }


        public int GetCurrentHealth()
        {
            return _currentHealth;
        }
    }
}