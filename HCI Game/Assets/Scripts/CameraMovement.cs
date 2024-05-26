using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //follow player
    [SerializeField] private Transform player;
    private void Update()
    {
        //room camera
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

        //follow player
        //transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    public void MovetoNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
