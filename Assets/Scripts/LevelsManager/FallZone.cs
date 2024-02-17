using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone : MonoBehaviour
{
    public GameObject Respawn_here;
    public ScoreManager scoreManager;
    public HealthManager healthManager;
    private bool recentlyTriggered = false;

    void ResetTrigger()
    {
        recentlyTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterControlScript player = other.GetComponent<CharacterControlScript>();

            if (player != null && !recentlyTriggered)
            {
                recentlyTriggered = true;
                int currentLives = player.CurrentLives;
                // Check if there are remaining lives
                if (currentLives > 0)
                {
                    // Respawn the player
                    Vector3 respawn = Respawn_here.transform.position;
                    other.transform.position = respawn;
                }
                else
                {
                    scoreManager.TakeScore(500);
                    healthManager.Restart();  // Reset health and game over state
                    // Set the damage with the script Attacker like with the enemies
                    healthManager.TakeDamage(healthManager.healthAmount);
                }
                // Reduce lives when the player touches the fall zone
                player.ReduceLives();
                Invoke("ResetTrigger", 1);

                // Optionally, update UI or perform other actions when lives are reduced
            }
        }
    }
}