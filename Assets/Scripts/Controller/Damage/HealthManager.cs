using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Keeps track of the health of the player
 */
public class HealthManager : MonoBehaviour
{

    public const float OriginalHealth= 100.0f;
    public Image healthBar;
    public float healthAmount = OriginalHealth;
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
        
    }

    public void TakeDamage(float damage) {
        EventManager.TriggerEvent<GenericEvent, string>("playerDamage"); // calls the player damage sound
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount) {
        // only heal if HP isn't full
        if (!this.isHpFull()) {
            healthAmount += healingAmount;
            healthAmount = Mathf.Clamp(healthAmount, 0, 100);
            EventManager.TriggerEvent<GenericEvent, string>("playerConsuming"); // calls the player consume sound
            healthBar.fillAmount = healthAmount / 100f;
        }
    }

    public bool isHpFull() {
        return !(this.healthAmount < OriginalHealth);
    }

    public bool isDead() {
        return this.healthAmount <= 0;
    }

    public void Restart() {
        this.isGameOver = false;
        this.healthAmount = 100f;
    }
}
