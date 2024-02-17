using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour {

    private CanvasGroup canvasGroup;
    public Canvas hudCanvas;
    public HealthManager healthManager;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape) && !healthManager.isDead()) {
            CanvasGroup hudCanvasGroup = hudCanvas.GetComponent<CanvasGroup>();
            
            if (canvasGroup.interactable) { // resume back to game
                disableCanvasGroup(canvasGroup);
                enableCanvasGroup(hudCanvasGroup);
                Time.timeScale = 1f;
            } else { // show pause menu
                disableCanvasGroup(hudCanvasGroup);
                enableCanvasGroup(canvasGroup);
                Time.timeScale = 0f;
            }
        }
    }

    private void enableCanvasGroup(CanvasGroup canvasGroupRef) {
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
