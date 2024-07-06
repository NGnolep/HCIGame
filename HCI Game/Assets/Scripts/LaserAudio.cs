using UnityEngine;

public class LaserAudio : MonoBehaviour
{
    public Transform target;
    public float maxVolumeDistance = 5f;
    public float minVolumeDistance = 20f;

    private AudioSource audioSource;
    private AudioManager audioManager;
    private Transform cameraTransform;
    private float globalVolume = 1f; // Global volume setting from the slider

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        // Ensure AudioSource is attached to the target object
        audioSource = target.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = target.gameObject.AddComponent<AudioSource>();
            Debug.LogWarning("AudioSource component not found on target. Adding AudioSource component.");
        }

        // Assign audio clip and settings
        if (audioManager != null && audioManager.Laser != null)
        {
            audioSource.clip = audioManager.Laser;
            audioSource.loop = true;
        }
        else
        {
            Debug.LogError("AudioManager or Laser clip is not assigned.");
        }

        // Play audio
        audioSource.Play();

        // Get main camera's transform
        cameraTransform = Camera.main.transform;

        // Load global volume setting from PlayerPrefs or default to 1
        LoadGlobalVolume();
    }

    private void LoadGlobalVolume()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            globalVolume = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            globalVolume = 1f;
        }
    }

    private void Update()
    {
        AdjustVolumeBasedOnDistance();
    }

    private void AdjustVolumeBasedOnDistance()
    {
        if (cameraTransform == null || audioSource == null) return;

        float distance = Vector3.Distance(cameraTransform.position, target.position);
        
        float volume = 0f;

        if (distance < maxVolumeDistance)
        {
            volume = globalVolume; // Apply global volume setting
        }
        else if (distance > minVolumeDistance)
        {
            volume = 0f;
        }
        else
        {
            volume = globalVolume * (1 - ((distance - maxVolumeDistance) / (minVolumeDistance - maxVolumeDistance)));
        }

        // Set volume to audio source
        audioSource.volume = volume;

        // Ensure audio is muted if global volume is set to 0
        if (globalVolume <= 0f)
        {
            audioSource.volume = 0f;
            audioSource.Stop();
        }
    }
}
