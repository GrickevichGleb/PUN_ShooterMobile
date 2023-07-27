using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private Image healthBarImage;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.up = Vector3.up;
            UpdateHealthBar();
        }


        private void UpdateHealthBar()
        {
            int currentHealth = health.GetCurrentHealth();
            int maxHealth = health.GetMaxHealth();

            healthBarImage.fillAmount = (float) currentHealth / maxHealth;
        }
    }
}
