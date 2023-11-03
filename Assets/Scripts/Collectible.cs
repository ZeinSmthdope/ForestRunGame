using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool recentlyThrown = false;
    public bool dirty = false;
    public bool isOnMap = true;

    private void Update()
    {
        // Item is recently thrown, enable kinematics
        if (recentlyThrown)
        {
            Debug.Log("[Collectible.cs] " + gameObject.name + " is recently thrown, disabled kinematics");
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Item is recently thrown, disable kinematics after collision with terrain
        if (recentlyThrown && collision.gameObject.name == "Terrain")
        {
            isOnMap = true;
            Debug.Log("[Collectible.cs] " + gameObject.name + " has collied with Terrain, enabled kinematics");
            recentlyThrown = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("[Collectible.cs] Collision " + gameObject.name);

        if (recentlyThrown) return; // This is true until the burger collides with Terrain
        if (!collision.attachedRigidbody) return; // Protect against null

        // Player has run into the item, pick it up & call the biz logic
        if (!dirty)
        {
            ItemCollector player = collision.attachedRigidbody.gameObject.GetComponent<ItemCollector>();
            if (player != null)
            {
                dirty = true;
                isOnMap = false;
                transform.localPosition = Vector3.zero;
                player.pickupItem(gameObject);
                Debug.Log("[Collectible.cs] Picked up " + gameObject.name);
                GetComponent<AudioSource>().Play(); // TODO call this as an event and remove audio source in Burger1
            }
        } else if (dirty) {
            EnemyControlScript enemy = collision.attachedRigidbody.gameObject.GetComponent<EnemyControlScript>();
            if (enemy != null && enemy.isDistracted)
            {
                isOnMap = false;
                transform.localPosition = Vector3.zero;
                Debug.Log("[Collectible.cs] Enemy collided while distracted " + gameObject.name);
            }
        }
    }
}