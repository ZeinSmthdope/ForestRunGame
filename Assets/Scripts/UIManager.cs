using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI livesText; // Reference to your TextMeshPro UI component
    private CharacterControlScript characterControl; // Reference to your CharacterControlScript

    void Start()
    {
        // Find the CharacterControlScript at the start
        characterControl = GameObject.FindObjectOfType<CharacterControlScript>();
    }

    void Update()
    {
        if (characterControl != null)
        {
            // Update the UI Text with the current lives from the CharacterControlScript
            livesText.text = "Lives: " + characterControl.lives.ToString();
        }
    }
}
