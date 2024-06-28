using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermissionCode : MonoBehaviour
{
    public void ExitStage()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
