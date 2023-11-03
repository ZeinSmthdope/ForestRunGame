using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class represents a model (e.g. bear, cat) that can hurt the player.
 */
public class Attacker : MonoBehaviour {

    // represents the damage the attacker can harm towards the player.
    public float damage;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public float getDamage() {
        return damage;
    }
}
