using System;
using Photon.Pun;
using UnityEngine;

namespace Networking
{
    public class GameController : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject gameOverPopUp;
        
        public int nPlayers;
        public event Action OnGameOver;


        private void OnDestroy()
        {
            // In case we loose 
            OnGameOver?.Invoke();
        }

        // Updating players count
        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            nPlayers = PhotonNetwork.PlayerList.Length;
        }

        public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
        {
            nPlayers = PhotonNetwork.PlayerList.Length;
        }


        private void GameOver()
        {
            OnGameOver?.Invoke();
            gameOverPopUp.SetActive(true);
        }
    }
}
