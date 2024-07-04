using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nasdaq : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverScreen;
    public bool over = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void gameover()
    {
        
        audioManager.PlaySFX(audioManager.Death);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

        over = false;
    }

    void dead()
    {
        //player.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Traps") || collision.CompareTag("DeathZone"))
        {
            
            over = true;
            dead();
            gameover();
        }
    }
}

