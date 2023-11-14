using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Keeps track of the health of the player
 */
public class HealthManager : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount = 100f;
    public CanvasGroup gameOverCanvasGroup;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

        // show game over when the health goes down to 0
        if(healthAmount <= 0 && !isGameOver) {
            GameOverMenu gameOverMenu = this.gameOverCanvasGroup.GetComponent<GameOverMenu>();
            gameOverMenu.showGameOverMenu();
            isGameOver = true;
        }

        // TODO give health when an event that allows healing happens (e.g. eating something)
        /*if (Input.GetKeyDown(KeyCode.Return)) {
            Heal(5);
        }*/
        
    }

    public void TakeDamage(float damage) {
        // TODO remove audio source in HealthManagerGameObj
        EventManager.TriggerEvent<GenericEvent, string>("playerDamage"); // calls the player damage sound
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount) {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Restart() {
        this.isGameOver = false;
        this.healthAmount = 100f;
    }
}
