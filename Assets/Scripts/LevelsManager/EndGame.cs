using UnityEngine;
using System.Collections;

//Winning script

public class EndGame : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public ScoreManager scoreManager;

    private void Awake()
    {

        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup component not found.");
        }

    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {

            InHouseTrigger bc = c.attachedRigidbody.gameObject.GetComponent<InHouseTrigger>();

            if (bc != null)
            {
                bc.InsideHouse();

                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
                Time.timeScale = 0f; // Pauses the game

                bc.inHouse = false;
                scoreManager.AddScore(1000);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // You might want to add some logic here if needed.
    }
}
