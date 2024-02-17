using UnityEngine;

public class TextFaceCamera : MonoBehaviour
{
    public GameObject Text;

    private Collectible collectible;

    void Start()
    {
        //Collectible script must be attached to the same GameObject
        collectible = GetComponent<Collectible>();
    }

    void Update()
    {
        if (Text != null && collectible != null && !collectible.isOnMap)
        {
            // Item is picked up, destroy the text
            Destroy(Text);
        }
        else if (Text != null)
        {
            // Text follows the camera orientation
            Text.transform.LookAt(Camera.main.transform.position);
            Text.transform.Rotate(0, 180, 0);
        }
    }
}