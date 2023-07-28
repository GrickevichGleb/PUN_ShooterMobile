using Photon.Pun;
using UnityEngine;

namespace Networking
{
    public class SpawnPlayers : MonoBehaviour
    {
        [SerializeField] private GameObject playerPref;
    
        // Start is called before the first frame update
        void Start()
        {
            SpawnPlayer();
        }
        

        private void SpawnPlayer()
        {
            Vector2 pos = new Vector2(6f, 0f);
            pos.y += Random.Range(-2, 3); // Bit of randomization 
            PhotonNetwork.Instantiate(playerPref.name, pos, Quaternion.identity);
        }
    }
}
