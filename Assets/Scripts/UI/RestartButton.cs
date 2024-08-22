using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class RestartButton : MonoBehaviour, IGameButton
{
    [SerializeField] private Button restartBtn;
    public ARSession arSession;

    private void Start() 
    {
        restartBtn.onClick.AddListener(Restart);

        if (arSession != null)
            arSession.enabled = true;
    }


    public void Restart() 
    {
        if (arSession != null)
        {
            arSession.Reset();
            Destroy(arSession.gameObject);
        }

        // Add additional cleanup if necessary
        // Example: Destroying AR Camera Manager, AR Plane Manager, etc.
        
        // Reload the scene
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
