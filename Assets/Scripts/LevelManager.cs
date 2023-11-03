using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform[] levelStartPoints; // Assign these in the inspector
    public int currentLevel = 0;
    public GameObject player; // Drag your player GameObject here in the inspector

    private void Start()
    {
        if (currentLevel < levelStartPoints.Length && player != null)
        {
            TeleportPlayerToLevelStart();
        }
    }

    public void AdvanceLevel()
    {
        currentLevel++;
        if (currentLevel < levelStartPoints.Length && player != null)
        {
            TeleportPlayerToLevelStart();
        }
        else
        {
            Debug.Log("All levels complete or player not set!");
            // Handle game completion or error here
        }
    }

    private void TeleportPlayerToLevelStart()
    {
        player.transform.position = levelStartPoints[currentLevel].position;
    }
}
