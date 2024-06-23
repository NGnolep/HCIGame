using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private bool isOpen = false;

    public void OpenGate()
    {
        if (!isOpen)
        {
            // Move the gate to an open position
            // Adjust the translation or rotation as needed for your gate
            transform.Translate(0, 2, 0); // Example translation, adjust as needed
            isOpen = true;
        }
    }
}

