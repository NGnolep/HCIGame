using System.Collections;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public Transform saw;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    public float maxVolumeDistance = 5f; // Jarak di mana volume mencapai maksimum
    public float minVolumeDistance = 20f; // Jarak di mana volume mencapai minimum
    
    private int direction = 1;
    private AudioSource sawAudioSource;
    private AudioManager audioManager;
    private Transform cameraTransform;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        sawAudioSource = saw.GetComponent<AudioSource>();

        if (sawAudioSource == null)
        {
            sawAudioSource = saw.gameObject.AddComponent<AudioSource>();
        }

        sawAudioSource.clip = audioManager.Laser;
        sawAudioSource.loop = true;
        sawAudioSource.Play();

        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        AdjustVolumeBasedOnDistance();

        Vector2 target = currentMovementTarget();

        saw.position = Vector2.Lerp(saw.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)saw.position).magnitude;
        if (distance < 0.1f)
        {
            direction *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    void AdjustVolumeBasedOnDistance()
    {
        if (cameraTransform == null || sawAudioSource == null) return;

        float distance = Vector3.Distance(cameraTransform.position, saw.position);

        if (distance < maxVolumeDistance)
        {
            sawAudioSource.volume = 1f;
        }
        else if (distance > minVolumeDistance)
        {
            sawAudioSource.volume = 0f;
        }
        else
        {
            float volume = 1 - ((distance - maxVolumeDistance) / (minVolumeDistance - maxVolumeDistance));
            sawAudioSource.volume = volume;
        }
    }

    private void OnDrawGizmos()
    {
        if (saw != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(saw.transform.position, startPoint.position);
            Gizmos.DrawLine(saw.transform.position, endPoint.position);
        }
    }
}
