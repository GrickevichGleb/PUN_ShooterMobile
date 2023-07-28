using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class Fighter : MonoBehaviourPunCallbacks, IPunObservable
    {
        [SerializeField] private GameObject gunFireBeam;
        [SerializeField] private float fireBeamRange;
        [SerializeField] private float firingTime = 1f;
        [Space] 
        [SerializeField] private int damage;

        public bool isFiring;

        private PlayerController _playerController;

        private Coroutine _firingCoroutine;

        private Vector3 _initScale;
        // Start is called before the first frame update
        void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _initScale = gunFireBeam.transform.localScale;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateFiringVis();
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
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Health>(out Health health))
            {
                health.TakeDamage(damage);
            }
        }


        public void Fire()
        {
            if(isFiring) 
                return;

            isFiring = true;
        }

        public int GetDamageVal()
        {
            return damage;
        }


        private void UpdateFiringVis()
        {
            gunFireBeam.SetActive(isFiring);
            if (isFiring && _firingCoroutine == null)
            {
                _firingCoroutine = StartCoroutine(Firing()); 
            }
                
        }
        

        private IEnumerator Firing()
        {
            // if(_firingCoroutine != null)
            //     StopCoroutine(_firingCoroutine);
            
            isFiring = true;
            Debug.Log("Fired");
            //Calculating scale based on initial 
            //Vector3 initScale = gunFireBeam.transform.localScale;
            Vector3 incrScale = _initScale;
            float speedMultiplier = 1f / firingTime;
            
            while (gunFireBeam.transform.localScale.y < fireBeamRange * 10f)
            {
                //multiply by 10 because beam vis has Y at 0.1 scale
                incrScale.y += fireBeamRange * Time.deltaTime * speedMultiplier * 10f;
                gunFireBeam.transform.localScale = incrScale;
                yield return null;
            }
            
            // Returning to initial state
            gunFireBeam.transform.localScale = _initScale;
            isFiring = false;
            
            _firingCoroutine = null;
        }
    }
}
