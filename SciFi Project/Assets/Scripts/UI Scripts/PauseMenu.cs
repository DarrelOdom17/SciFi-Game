using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject resumeButton;
    [SerializeField]
    GameObject mainMenuButton;
    [SerializeField]
    GameObject optionsButton;

    [SerializeField]
    TextMeshProUGUI enemyCounter_TMP;

    [HideInInspector]
    public int enemyCount;

    [SerializeField]
    GameObject menuLayout;
    
    //Gets reference to player canvas in hierarchy
    private GameObject playerCanvas;
    private GameObject gun;
    private MouseLook cursorLock;
    public GameObject winCanvas;
    public GameObject GameUI;


    /// <summary>
    /// References a variable state across all classes
    /// </summary>
    public static bool gameIsPaused = false;

    private void Start()
    {
        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
        menuLayout.SetActive(false);
        playerCanvas = GameObject.Find("PlayerCanvas");
        gun = GameObject.Find("Gun");
        cursorLock = GameObject.Find("Player").GetComponent<MouseLook>();
        winCanvas.SetActive(false);
        GameUI = GameObject.Find("GameUI");
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

        if (enemyCounter_TMP != null)
        {
            enemyCounter_TMP.text = "Enemies Left: " + enemyCount;
            if (enemyCount <= 0)
            {
                WinState();
            }
        }
    }

    public void WinState()
    {
        winCanvas.SetActive(true);
        playerCanvas.SetActive(false);
        GameUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        gun.SetActive(false);
        Time.timeScale = 0f;

    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        gun.SetActive(false);
        playerCanvas.SetActive(false);              // Disables player canvas in pause menu
        menuLayout.SetActive(true);
        resumeButton.SetActive(true);
        mainMenuButton.SetActive(true);
        optionsButton.SetActive(true);
        gameIsPaused = true;

        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gun.SetActive(true);
        playerCanvas.SetActive(true);               // Reinables player canvas when game is unpaused
        menuLayout.SetActive(false);
        resumeButton.SetActive(false);
        mainMenuButton.SetActive(false);
        optionsButton.SetActive(false);
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
