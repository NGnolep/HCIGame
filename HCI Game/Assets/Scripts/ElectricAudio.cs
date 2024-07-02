using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricAudio : MonoBehaviour
{
    public Transform target;
    public float maxVolumeDistance = 5f;
    public float minVolumeDistance = 20f;

    private AudioSource audioSource;
    private AudioManager audioManager;
    private Transform cameraTransform;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        audioSource = target.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = target.gameObject.AddComponent<AudioSource>();
            Debug.LogWarning("AudioSource component not found on target. Adding AudioSource component.");
        }

        audioSource.clip = audioManager.Electric;
        audioSource.loop = true;
        audioSource.Play();

        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        AdjustVolumeBasedOnDistance();
    }

    void AdjustVolumeBasedOnDistance()
    {
        if (cameraTransform == null || audioSource == null) return;

        float distance = Vector3.Distance(cameraTransform.position, target.position);
        Debug.Log($"Distance to target: {distance}");

        float volume = 0f;

        if (distance < maxVolumeDistance)
        {
            volume = 1f;
        }
        else if (distance > minVolumeDistance)
        {
            volume = 0f;
        }
        else
        {
            volume = 1 - ((distance - maxVolumeDistance) / (minVolumeDistance - maxVolumeDistance));
        }

        Debug.Log($"Calculated volume: {volume}");

        audioSource.volume = volume;
    }
}
