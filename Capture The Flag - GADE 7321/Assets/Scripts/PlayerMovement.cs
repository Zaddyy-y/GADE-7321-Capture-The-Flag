using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES
    public float playerSpeed = 10f;
    public CharacterController characterController;
    public Rigidbody rb;
    public Vector3 playerVelocity;
    public GameObject blueFlag;
   
    
    void Start()
    {
       characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();


    }

    
    void Update()
    {
       playerVelocity = Camera.main.transform.forward * Input.GetAxis("Vertical") + //ALLOWS THE PLAYER TO MOVE IN EITHER DIRECTION RELATIVE TO THE CAMERAS POSITION
                      Camera.main.transform.right * Input.GetAxis("Horizontal");

       characterController.SimpleMove(playerVelocity * playerSpeed); // DETERMINES THE DIRECTION AND SPEED OF THE PLAYER CHARACTER'S MOVEMENT USING THE SIMPLE MOVE METHOD
  
    }

    private void OnTriggerEnter(Collider other) // ALLOWS THE PLAYER TO PICK UP THE BLUE FLAG IF THE TAG MATCHES
    {
        if (other.CompareTag("Blue Flag"))
        {
            blueFlag = other.gameObject;
            Destroy(blueFlag);
        }
    }

    
}
