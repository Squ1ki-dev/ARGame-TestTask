using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int totalScore = 0;
    [SerializeField] private ScoreDisplay scoreDisplay;

    private void Start() => scoreDisplay.UpdateScore(totalScore);

    public void AddScore()
    {
        totalScore++;
        scoreDisplay.UpdateScore(totalScore);
    }
}
