using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Collections;

public class LoadNextSceneOnCameraUnfollow : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private Transform lastFollowedObject;

    void Start()
    {
        if (virtualCamera != null)
        {
            lastFollowedObject = virtualCamera.Follow;
        }
    }

    void Update()
    {
        // Periksa apakah objek yang diikuti telah berubah atau null
        if (virtualCamera != null && virtualCamera.Follow != lastFollowedObject)
        {
            if (virtualCamera.Follow == null)
            {
                // Objek yang diikuti telah dihapus atau tidak aktif
                StartCoroutine(Transition(1f));
            }
            lastFollowedObject = virtualCamera.Follow;
        }
    }

    private IEnumerator Transition(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
