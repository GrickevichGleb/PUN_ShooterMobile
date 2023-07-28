using System;
using EnvObjects;
using Photon.Pun;
using Player;
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
            
            CheckGameOver();
        }


        public void GameOver()
        {
            OnGameOver?.Invoke();
            gameOverPopUp.SetActive(true);
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                
                gameOverPopUp.GetComponent<GameOverPopUp>().
                    SetWinnerInfo(
                        playerObj.GetComponent<PlayerController>().GetNickName(),
                        playerObj.GetComponent<CoinCounter>().GetCoinsCollectedN()
                        );

            }
        }


        private void CheckGameOver()
        {
            if (nPlayers == 1)
            {
                // If only one player left
                GameOver();
            }
        }
    }
}
