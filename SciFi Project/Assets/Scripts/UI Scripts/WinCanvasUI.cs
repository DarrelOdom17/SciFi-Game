using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvasUI : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenuButton;
    [SerializeField]
    GameObject QuitButton;
    //[SerializeField]
    //GameObject menuLayout;

    private GameObject winCanvas;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameWin()
    {
        winCanvas.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#endif
        Debug.Log("Game has closed!");
    }
}
