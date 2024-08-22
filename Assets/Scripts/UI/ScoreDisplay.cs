using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public void UpdateScore(int newScore) => scoreText.text = "Score: " + newScore.ToString();
}
