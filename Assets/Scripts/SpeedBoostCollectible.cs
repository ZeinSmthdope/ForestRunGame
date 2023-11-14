using UnityEngine;

public class SpeedBoostCollectible : MonoBehaviour
{
    public float speedIncrease = 10f;
    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterControlScript playerControlScript = other.GetComponent<CharacterControlScript>();
            if (playerControlScript != null)
            {
                playerControlScript.ApplyTemporarySpeedBoost(speedIncrease, duration);
                Destroy(gameObject); // Destroy the collectible immediately after collection
            }
        }
    }
}
