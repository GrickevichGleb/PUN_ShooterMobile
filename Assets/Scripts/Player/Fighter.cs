using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class Fighter : MonoBehaviourPunCallbacks, IPunObservable
    {
        [SerializeField] private GameObject gunFireBeam;
        [Space] 
        [SerializeField] private int damage;

        public bool isFiring;

        private PlayerController _playerController;
        

        // Start is called before the first frame update
        void Start()
        {
            _playerController = GetComponent<PlayerController>();
            gunFireBeam.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            UpdateFiringVis();
            
            if (!_playerController.GetPhotonView().IsMine) return;
            
            if (Input.GetKeyDown(KeyCode.Space) && !isFiring)
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


        public int GetDamageVal()
        {
            return damage;
        }


        private void UpdateFiringVis()
        {
            gunFireBeam.SetActive(isFiring);
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
