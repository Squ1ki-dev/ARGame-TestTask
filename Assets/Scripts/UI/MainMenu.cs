using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Button playBtn, exitBtn;

    private void Start()
    {
        playBtn.onClick.AddListener(Play);
        exitBtn.onClick.AddListener(QuitApplication);
    }

    private void Play() => menuPanel.SetActive(false);
    public void QuitApplication() => Application.Quit();
}
