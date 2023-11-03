using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Shows blinking message telling the player that 
 * they're heading the wrong way when told to.
 */
[RequireComponent(typeof(CanvasGroup))]
public class WrongWayOverlay : MonoBehaviour {

    private CanvasGroup canvasGroup;
    private bool alternate;
    private bool showWrongWay;
    // Start is called before the first frame update
    void Start() {
        // call blinkOverlay method every second
        InvokeRepeating("blinkOverlay", 0, 1.0f);
        this.alternate = true;
        this.showWrongWay = false;
    }

    // Update is called once per frame
    void Update() {
    }

    public void enableWrongWayOverlay() {
        this.showWrongWay = true;
        this.alternate = true;
    }

    public void disableWrongWayOverlay() {
        this.showWrongWay = false;
        this.alternate = false;
        disableCanvasGroup(canvasGroup);
    }

    public bool isShowingWrongWay() {
        return this.showWrongWay;
    }

    public void blinkOverlay() {
        if (this.showWrongWay) {
            if (this.alternate) {
                // show wrong way overlay
                enableCanvasGroup(canvasGroup);
            } else {
                // hide wrong way overlay
                disableCanvasGroup(canvasGroup);
            }
            this.alternate = !this.alternate;
        }
    }

    private void enableCanvasGroup(CanvasGroup canvasGroupRef) {
        canvasGroupRef.interactable = true;
        canvasGroupRef.alpha = 1f;
    }

    private void disableCanvasGroup(CanvasGroup canvasGroupRef) {
        canvasGroupRef.interactable = false;
        canvasGroupRef.alpha = 0f;
    }

    void Awake() {
        this.canvasGroup = GetComponent<CanvasGroup>();
    }

}
