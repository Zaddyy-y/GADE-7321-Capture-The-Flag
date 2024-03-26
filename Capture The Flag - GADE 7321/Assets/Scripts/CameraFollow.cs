using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;

    void Start()
    {

    }


    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + cameraOffset;
            transform.LookAt(player);
        }
    }
}
