using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class GameOverScreen : MonoBehaviour, IGameButton
{
    [SerializeField] private Button restartBtn, exitBtn;

    private void Start()
    {
        restartBtn.onClick.AddListener(Restart);
        exitBtn.onClick.AddListener(Exit);
    }

    public void Restart()
    {
        ARSession arSession = GetComponent<ARSession>();
        arSession.Reset();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Exit() => Application.Quit();
}
