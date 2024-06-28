using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clickSound;

    void Start()
    {
        // Find the AudioManager GameObject and get its AudioSource component
        GameObject audioManager = GameObject.Find("AudioManager");
        if (audioManager != null)
        {
            audioSource = audioManager.GetComponent<AudioSource>();
        }
    }

    public void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
