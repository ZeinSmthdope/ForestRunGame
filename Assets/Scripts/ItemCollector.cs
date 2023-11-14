using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    // Start is called before the first frame update
    public Stack<GameObject> items = new Stack<GameObject>();
    public ScoreManager scoreManager;
    private bool isOnCooldown = false;

    public void pickupItem(GameObject item)
    {
        items.Push(item);
        scoreManager.AddScore(250);
    }

    void ResetCooldown()
    {
        isOnCooldown = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            throwItem();
        }
    }

    private void throwItem()
    {
        if (isOnCooldown) return;
        if (items.Count > 0)
        {
            isOnCooldown = true;
            GameObject item = items.Pop();
            item.GetComponent<Collectible>().recentlyThrown = true;
            // TODO remove audio source in player
            EventManager.TriggerEvent<GenericEvent, string>("collectableDrop"); // plays the collectable drop sound
            item.GetComponent<Collectible>().isOnMap = true;
            item.transform.rotation = transform.rotation;
            item.transform.position = transform.position + new Vector3(0, 4, 0);
            scoreManager.TakeScore(250);
            Invoke("ResetCooldown", 0.25f);
        }
    }
}
