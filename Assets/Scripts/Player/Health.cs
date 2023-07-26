using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class Health : MonoBehaviourPunCallbacks, IPunObservable
    {
        [SerializeField] private int startHealth = 100;
    
        private int _currentHealth;


        private void Start()
        {
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
