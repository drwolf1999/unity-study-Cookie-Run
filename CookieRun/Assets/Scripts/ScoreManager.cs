using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] PlayerInteraction playerInteraction;

    int recentScore = -1;
    int currentScore;
    void Update()
    {
        currentScore = playerInteraction.GetScore();
        if (recentScore != currentScore)
        {
            scoreText.text = currentScore.ToString();
        }
    }
}
