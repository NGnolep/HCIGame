using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private static PauseManager instance;
    private bool isPaused = false;

    void Awake()
    {
        // Reset Time.timeScale when the game starts or a scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset time scale when a new scene is loaded
        ResetTimeScale();
    }

    void Update()
    {
        // Check if the player presses the pause key (e.g., Escape key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Load the PauseMenuScene additively
        SceneManager.LoadScene("Pause Menu", LoadSceneMode.Additive);
        Time.timeScale = 0f; // Stop the game time
        isPaused = true;
    }

    public void ContinueGame()
    {
        // Unload the PauseMenuScene
        SceneManager.UnloadSceneAsync("Pause Menu");
        Time.timeScale = 1f; // Resume the game time
        isPaused = false;
    }

    void ResetTimeScale()
    {
        Time.timeScale = 1f; // Ensure the game is not paused
        isPaused = false;    // Reset pause state
    }
}
