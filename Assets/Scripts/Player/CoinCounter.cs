using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Player
{
    public class CoinCounter : MonoBehaviourPunCallbacks, IPunObservable
    {
        private TMP_Text _coinCounterDisp;
        private int _coinsCollected;
    
        // Start is called before the first frame update
        void Start()
        {
            _coinCounterDisp = GameObject.FindWithTag("CoinCounter").GetComponent<TMP_Text>();
        }
        

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                // We own this player: send the others our data
                stream.SendNext(_coinsCollected);
            }
            else
            {
                // Network player, receive data
                this._coinsCollected = (int)stream.ReceiveNext();
            }
        }

        public void CollectCoin()
        {
            _coinsCollected += 1;

            // Updating display counter only for our own player 
            if (!GetComponent<PlayerController>().GetPhotonView().IsMine)
                return;
            _coinCounterDisp.text = "$: " + _coinsCollected;
        }

        public int GetCoinsCollectedN()
        {
            return _coinsCollected;
        }
    }
}
