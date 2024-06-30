using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform saw;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    int direction = 1;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        audioManager.PlaySFX(audioManager.Saw);
        
        Vector2 target = currentMovementTarget();

        saw.position = Vector2.Lerp(saw.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)saw.position).magnitude;
        if(distance < 0.1f)
        {
            direction *= -1; 
        }
    }

    Vector2 currentMovementTarget()
    {
        if(direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }
    private void OnDrawGizmos()
    {
        if(saw != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(saw.transform.position, startPoint.position);
            Gizmos.DrawLine(saw.transform.position, endPoint.position);
        }
    }
}
