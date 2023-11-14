using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Helps show the game over menu and the controls
 */
[RequireComponent(typeof(CanvasGroup))]
public class GameOverMenu : MonoBehaviour {

    private CanvasGroup canvasGroup;
    public Canvas hudCanvas;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
    }

    public void showGameOverMenu() {
        CanvasGroup hudCanvasGroup = hudCanvas.GetComponent<CanvasGroup>();
        
        // hide the HUD (HP and score)
        disableCanvasGroup(hudCanvasGroup);
        // show game over
        enableCanvasGroup(canvasGroup);
        // freeze the game
        Time.timeScale = 0f;
    }

    private void enableCanvasGroup(CanvasGroup canvasGroupRef) {
        // TODO remove audio source in GameOverCanvas
        EventManager.TriggerEvent<GenericEvent, string>("gameOver"); // calls the game over sound
        canvasGroupRef.interactable = true;
        canvasGroupRef.blocksRaycasts = true;
        canvasGroupRef.alpha = 1f;
    }

    private void disableCanvasGroup(CanvasGroup canvasGroupRef) {
        canvasGroupRef.interactable = false;
        canvasGroupRef.blocksRaycasts = false;
        canvasGroupRef.alpha = 0f;
    }

    void Awake() {
        this.canvasGroup = GetComponent<CanvasGroup>();
    }

}
