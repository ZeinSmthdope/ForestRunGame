using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCollectible : MonoBehaviour
{
    public int extraLives = 1; // Number of extra lives provided by collecting this item

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterControlScript player = other.GetComponent<CharacterControlScript>();

            if (player != null)
            {
                player.AddLives(extraLives);
                Destroy(gameObject); // Destroy the collectible after it's picked up
            }
        }
    }
}