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
    public AudioClip WallMoving;
    public AudioClip Saw;
    public AudioClip GroundCrack;
    public AudioClip PressurePlate;
    public AudioClip PlatformMoving;
    public AudioClip CharacterJump;
    public AudioClip Laser;
    public AudioClip Electric;
    public AudioClip Death;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
