using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform prevRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraMovement cam;

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(collision.transform.position.x < transform.position.x)
            {
                cam.MovetoNewRoom(nextRoom);
            } else
            {
                cam.MovetoNewRoom(prevRoom);
            }
        }
    }
}
