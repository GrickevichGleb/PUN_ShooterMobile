using TMPro;
using UnityEngine;

namespace Player
{
    public class NameDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;

        private PlayerController _playerController;
        private string _name;
        
        // Start is called before the first frame update
        void Start()
        {
            nameText.text = GetComponentInParent<PlayerController>().GetNickName();
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = transform.parent.position + Vector3.up;
            transform.up = Vector3.up;
        }
    }
}
