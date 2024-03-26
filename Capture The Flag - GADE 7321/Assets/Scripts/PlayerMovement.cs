using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    public CharacterController characterController;
    public Rigidbody rb;
    public Vector3 playerVelocity;
   
    
    void Start()
    {
       characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
       playerVelocity = Camera.main.transform.forward * Input.GetAxis("Vertical") +
                      Camera.main.transform.right * Input.GetAxis("Horizontal");

       characterController.SimpleMove(playerVelocity * playerSpeed);
  
    }
}
