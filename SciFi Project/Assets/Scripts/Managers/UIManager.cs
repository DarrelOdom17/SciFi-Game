using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject resumeButton;
    [SerializeField]
    GameObject mainMenuButton;

    public static UIManager instance;

    [SerializeField]
    TextMeshProUGUI enemyCounter_TMP;

    [HideInInspector]
    public int enemyCount;

    [SerializeField]
    GameObject menuLayout;


    /// <summary>
    /// References a variable state across all classes
    /// </summary>
    public static bool gameIsPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!gameIsPaused)
                Pause();
            else
                Resume();
        }

        enemyCounter_TMP.text = "Enemies Left: " + enemyCount;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        menuLayout.SetActive(false);
    }

   public void Pause()
    {
        menuLayout.SetActive(true);
        resumeButton.SetActive(true);
        mainMenuButton.SetActive(true);
        gameIsPaused = true;

        Time.timeScale = 0f;
    }

    public void Resume()
    {
        menuLayout.SetActive(false);
        resumeButton.SetActive(false);
        mainMenuButton.SetActive(false);
        gameIsPaused = false;

        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        // Application.Quit();
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
