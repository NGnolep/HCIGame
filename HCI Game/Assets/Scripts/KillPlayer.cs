using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverScreen;
    public bool over = false;

    public CinemachineVirtualCamera virtualCamera; // Assign in Inspector
    AudioManager audioManager;
    SpriteRenderer spriteRenderer;
    PlayerOneMovement playerMovement;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        playerMovement = player.GetComponent<PlayerOneMovement>();
    }

    public void gameover()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        over = false;
    }

    void dead()
    {
        // Menonaktifkan Sprite Renderer
        spriteRenderer.enabled = false;

        // Menonaktifkan skrip Player One Movement
        playerMovement.enabled = false;

        // Menghentikan Cinemachine Virtual Camera dari mengikuti objek apapun
        if (virtualCamera != null)
        {
            virtualCamera.Follow = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Traps") || collision.CompareTag("DeathZone"))
        {
            over = true;
            dead();
            audioManager.PlaySFX(audioManager.Death);
            StartCoroutine(GameOverRoutine(1f));
        }
    }

    private IEnumerator GameOverRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameover(); // Load game over scene
    }
}
