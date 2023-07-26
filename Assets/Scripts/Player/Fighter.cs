using System.Collections;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class Fighter : MonoBehaviourPunCallbacks, IPunObservable
    {
        public bool isFiring;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Firing());
            }
        }

        // IPunObservable implementation
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                // We own this player: send the others our data
                stream.SendNext(isFiring);
            }
            else
            {
                // Network player, receive data
                this.isFiring = (bool)stream.ReceiveNext();
            }
        }


        private IEnumerator Firing()
        {
            isFiring = true;
            Debug.Log("Fired");
            yield return new WaitForSeconds(1f);
            isFiring = false;
        }
    }
}
