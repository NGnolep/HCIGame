using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool isDown = false;
    public Vector3 downPosition;
    private Vector3 upPosition;
    public float transitionDuration = 0.1f; // Duration for the platform to move

    AudioManager audioManager;
    private Coroutine currentCoroutine = null;
    private AudioSource platformAudioSource;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        platformAudioSource = gameObject.AddComponent<AudioSource>();
        platformAudioSource.clip = audioManager.PlatformMoving;
        platformAudioSource.loop = true;
    }

    void Start()
    {
        upPosition = transform.position;
    }

    public void MoveDown()
    {
        if (!isDown)
        {
            Debug.Log("Platform moving down");
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            platformAudioSource.Play();
            currentCoroutine = StartCoroutine(MovePlatform(downPosition));
            isDown = true;
        }
    }

    public void MoveUp()
    {
        if (isDown)
        {
            Debug.Log("Platform moving up");
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
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
}
