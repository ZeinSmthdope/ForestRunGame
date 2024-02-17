using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Represents a model that can be attacked by an model that contains the Attacker component.
 */
public class Attackable : MonoBehaviour
{

    public HealthManager healthManager;

    void OnTriggerEnter(Collider c)
    {

        // lower damage if the attacker and the player make contact.
        if (c != null)
        {
            Attacker attacker = c.gameObject.GetComponent<Attacker>();

            if (attacker != null)
            {
                healthManager.TakeDamage(attacker.getDamage());
            }
        }
    }
}
