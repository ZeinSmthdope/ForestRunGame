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
    [SerializeField]
    private TMP_Text collectibleText;
    public int score = 0;
    public int collectibles = 0;
    public int lives = 3; // Initial number of lives


    public CharacterControlScript characterControlScript;


    private void Start()
    {
        scoreText.SetText("Score: 000");
    }

    public void TakeScore(int points)
    {
        score -= points;
        scoreText.SetText("Score: " + GetScore());
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.SetText("Score: " + GetScore());
    }

    public string GetScore()
    {
        return score.ToString();
    }

    public void AddCollectible()
    {
        collectibles += 1;
        collectibleText.SetText("Food: " + GetCollectibles());
    }

    public void TakeCollectible()
    {
        collectibles -= 1;
        collectibleText.SetText("Food: " + GetCollectibles());
    }

    public string GetCollectibles()
    {
        return collectibles.ToString();
    }
}
