using Player;
using UnityEngine;

namespace EnvObjects
{
    public class Coin : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<CoinCounter>(out CoinCounter playerCoinCounter))
            {
                playerCoinCounter.CollectCoin();
            }
        
            Destroy(gameObject);
        }
    }
}
