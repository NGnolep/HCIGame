using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Source ----------")]
    public AudioClip background;
    public AudioClip buttonClick;
    public AudioClip backButtonClick;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    

}
