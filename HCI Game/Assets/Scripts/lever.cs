using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lever : MonoBehaviour
{
    public Gate gate; // Reference to the Gate script
    public GameObject laser;
    private bool isActivated = false;
    private Animator leverAnim;
    AudioManager audioManager;
    private void Awake()
    {
        leverAnim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isActivated)
            {
                audioManager.PlaySFX(audioManager.PressurePlate);
                ActivateLever();
            }
        }
    }

    void ActivateLever()
    {
        // Rotate the lever to show it has been activated
        leverAnim.enabled = true;
        leverAnim.Play("lever");// Example rotation, adjust as needed
        isActivated = true;
        

        // Notify the gate to open
        if (gate != null)
        {
            gate.OpenGate();
        }
        else if (laser != null)
        {
            Destroy(laser);
        }
        else
        {
            Debug.LogWarning("Neither Gate nor Laser GameObject is assigned in the Lever script.");
        }


        /*gate.OpenGate();

        if (laser != null)
        {
            Destroy(laser);
        }
        else
        {
            Debug.LogWarning("Laser GameObject is not assigned in the lever script");
        }*/
    }
}
