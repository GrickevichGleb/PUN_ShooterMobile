using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Networking
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        // Start is called before the first frame update
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        // Called when user connected
        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }

    
        // When joined lobby loads lobby scene
        public override void OnJoinedLobby()
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
