using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnvObjects
{
    public class GameOverPopUp : MonoBehaviour
    {
        [SerializeField] private TMP_Text winnerNameText;
        [SerializeField] private TMP_Text winnerCoinsCountText;


        public void SetWinnerInfo(string name, int coins)
        {
            winnerNameText.text = "Winner: " + name;
            winnerCoinsCountText.text = "Collected " + coins + " coins";
        }


        public void BackToLoadingScene()
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene(0);
        }
    }
}
