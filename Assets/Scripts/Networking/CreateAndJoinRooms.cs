using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Networking
{
    public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField createInput;
        [SerializeField] private TMP_InputField joinInput;


        // For Create button
        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(createInput.text);
        }


        // For Join button
        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(joinInput.text);
        }


        // When joined load actual mp level scene
        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }
}
