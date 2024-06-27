using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool isOpen = false;
    public Vector3 openPosition;
    private Vector3 closedPosition;
    public float transitionDuration = 1.0f; // Duration for the gate to open or close

    private Coroutine currentCoroutine = null;

    void Start()
    {
        closedPosition = transform.position;
    }

    public void OpenGate()
    {
        if (!isOpen)
        {
            Debug.Log("Gate opened");
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = StartCoroutine(MoveGate(openPosition));
            isOpen = true;
        }
    }

    public void CloseGate()
    {
        if (isOpen)
        {
            Debug.Log("Gate closed");
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = StartCoroutine(MoveGate(closedPosition));
            isOpen = false;
        }
    }

    private IEnumerator MoveGate(Vector3 targetPosition)
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
    }

    /*public bool isOpen = false;
    public Vector3 openPosition;
    private Vector3 closedPosition;

    void Start()
    {
        closedPosition = transform.position;
    }

    public void OpenGate()
    {
        if (!isOpen)
        {
            Debug.Log("Gate opened");
            // Move the gate to an open position
            // Adjust the translation or rotation as needed for your gate
            // Example: Move the gate upwards by 3 units
            transform.position = openPosition; // Adjust as needed
            isOpen = true;
        }
    }

    public void CloseGate()
    {
        if (isOpen)
        {
            // Move the gate back to its original position
            // Adjust the translation or rotation as needed for your gate
            // Example: Move the gate downwards by 3 units
            transform.position = closedPosition; // Adjust as needed
            isOpen = false;
        }
    }*/
}

