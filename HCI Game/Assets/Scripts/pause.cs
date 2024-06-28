using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
    }

    void ContinueGame()
    {
        // Find the PauseManager and call ContinueGame
        PauseManager pauseManager = FindObjectOfType<PauseManager>();
        if (pauseManager != null)
        {
            pauseManager.ContinueGame();
        }
    }
}
