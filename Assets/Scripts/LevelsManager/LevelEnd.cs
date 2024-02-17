using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plyr"))
        {
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null)
            {
                levelManager.AdvanceLevel();
            }
            else
            {
                Debug.LogError("Level Manager not found!");
            }
        }
    }
}
