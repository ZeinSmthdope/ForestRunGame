using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Checks to see if the distance between the
 * player and the objective is increasing and
 * thus an alert to the user gets shown.
 */
public class WrongWayChecker : MonoBehaviour {

    public GameObject player;
    public GameObject objective; // waypoint to get player to be in
    private WrongWayOverlay wrongWayOverlay;
    private float prevDist;
    private int secondsPast;
    public int maximumSeconds; // max seconds to allow player to go wrong way before alerting

    // Start is called before the first frame update
    void Start() {

        prevDist = float.MaxValue;
        secondsPast = 0;
        wrongWayOverlay = GetComponent<WrongWayOverlay>();

        // check distance every second
        InvokeRepeating("checkDistance", 0, 1.0f);

    }

    // Update is called once per frame
    void Update() {
    }

    public void checkDistance() {
        float distance = Vector3.Distance(player.transform.position, objective.transform.position);
        
        // Debug.Log($"distance: {distance} prevDist: {prevDist} secondsPast: {secondsPast} maximumSeconds: {maximumSeconds}");

        // show the wrong way overlay if the distance between player
        // and objective has gone up past a certain threshold (maximumSeconds)
        if (distance > prevDist) {
            if (!this.wrongWayOverlay.isShowingWrongWay() && secondsPast >= maximumSeconds) {
                Debug.Log("Enabling wrong way overlay message");
                this.wrongWayOverlay.enableWrongWayOverlay();
            }
            secondsPast++;
        } else {
            secondsPast = 0; // reset time
            if (this.wrongWayOverlay.isShowingWrongWay()) {
                // disable the overlay otherwise (should only be called once)
                Debug.Log("Disabling wrong way overlay message");
                this.wrongWayOverlay.disableWrongWayOverlay();
            }
        }

        prevDist = distance;
        
    }
}
