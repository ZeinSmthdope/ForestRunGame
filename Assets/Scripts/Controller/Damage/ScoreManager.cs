using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * Keeps track of the score of the player
 */
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    private int score = 0;

    private void Start()
    {
        scoreText.SetText("Score: 000");
    }

    public void TakeScore(int points) {
        score -= points;
        scoreText.SetText("Score: " + GetScore());
    }

    public void AddScore(int points) {
        score += points;
        scoreText.SetText("Score: " + GetScore());
    }

    public string GetScore() {
        return score.ToString();
    }
}
