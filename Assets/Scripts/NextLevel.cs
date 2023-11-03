using UnityEngine;
using System.Collections;

//Teleports the player to the next level on the map
//set boolean to true when entering house, this could be used for animation
//and adds 1000 to score

public class NextLevel : MonoBehaviour
{
    public GameObject player;
    public GameObject nextLevelObject;
    public ScoreManager scoreManager;


    private void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {

            InHouseTrigger bc = c.attachedRigidbody.gameObject.GetComponent<InHouseTrigger>();

            if (bc != null)
            {
                bc.InsideHouse();

                //Teleports the player to the next level on the map
                Vector3 nextLevel = nextLevelObject.transform.position;
                player.transform.position = nextLevel;

                //Resets Boolean 
                bc.inHouse = false;

                //Adds 1000
                scoreManager.AddScore(500);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //add some logic if needed.
    }
}