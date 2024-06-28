using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermissionCode : MonoBehaviour
{
    public void ExitStage()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void Continue2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
