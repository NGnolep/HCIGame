using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lever : MonoBehaviour
{
    public Gate gate; // Reference to the Gate script
    private bool isActivated = false;
    private Animator leverAnim;

    private void Awake()
    {
        leverAnim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isActivated)
            {
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
        gate.OpenGate();
    }
}
