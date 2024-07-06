using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool isDown = false;
    public Vector3 downPosition;
    private Vector3 upPosition;
    public float transitionDuration = 0.1f;

    private AudioManager audioManager;
    private Coroutine currentCoroutine = null;
    private AudioSource platformAudioSource;
    private float globalVolume = 1f;
    private const float maxVolume = 0.5f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        platformAudioSource = gameObject.AddComponent<AudioSource>();
        platformAudioSource.clip = audioManager.PlatformMoving;
        platformAudioSource.loop = true;
        LoadGlobalVolume();
    }

    void Start()
    {
        upPosition = transform.position;
    }

    private void LoadGlobalVolume()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            globalVolume = PlayerPrefs.GetFloat("musicVolume") * maxVolume;
        }
        else
        {
            globalVolume = maxVolume;
        }
    }

    public void MoveDown()
    {
        if (!isDown)
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            platformAudioSource.volume = globalVolume;
            platformAudioSource.Play();
            currentCoroutine = StartCoroutine(MovePlatform(downPosition));
            isDown = true;
        }
    }

    public void MoveUp()
    {
        if (isDown)
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            platformAudioSource.volume = globalVolume;
            platformAudioSource.Play();
            currentCoroutine = StartCoroutine(MovePlatform(upPosition));
            isDown = false;
        }
    }

    private IEnumerator MovePlatform(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < transitionDuration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        platformAudioSource.Stop();
    }

    private void Update()
    {
        LoadGlobalVolume();
    }
}
