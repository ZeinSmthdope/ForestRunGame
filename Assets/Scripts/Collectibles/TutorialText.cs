using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public GameObject Tutorial_Text;
    private Collectible collectible;

    void Start()
    {
        collectible = GetComponent<Collectible>(); // Script is attached to the same GameObject as the collectible
        if (Tutorial_Text == null)
        {
            Debug.LogError("TutorialText script requires a reference to the Canvas GameObject.");
        }
        else
        {
            //Disable the text initially
            Tutorial_Text.SetActive(false);
        }
    }

    //Enable the text when the collectible is collected
    private void OnTriggerEnter(Collider other)
    {
        if (collectible != null && !collectible.isOnMap)
        {
            Tutorial_Text.SetActive(true);

            //Automatically disable the text after set seconds
            Invoke("DisableText", 7f);
        }
    }

    void DisableText()
    {
        Tutorial_Text.SetActive(false);
    }
}