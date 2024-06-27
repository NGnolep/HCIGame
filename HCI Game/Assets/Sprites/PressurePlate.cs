using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Gate gate;
    public MovingPlatform platform;
    private bool isActivated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called with: " + other.tag);
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            Debug.Log("Pressure plate activated by: " + other.tag);
            isActivated = true;
            // Perform actions when activated (e.g., open door)
            if (gate != null && !gate.isOpen)
            {
                gate.OpenGate();
            }
            if (platform != null && !platform.isDown)
            {
                platform.MoveDown();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("OnTriggerExit2D called with: " + other.tag);
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            Debug.Log("Pressure plate deactivated by: " + other.tag);
            isActivated = false;
            // Perform actions when deactivated (e.g., close door)
            if (gate != null && gate.isOpen)
            {
               // gate.CloseGate();
            }
            if (platform != null && platform.isDown)
            {
                platform.MoveUp();
            }
        }
    }
}
