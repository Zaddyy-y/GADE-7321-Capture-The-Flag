using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class FSM : MonoBehaviour
{
    //VARIABLES
    public GameObject player;
    public GameObject playerStartingLocation;
    public GameObject flagLocationObject;
    public GameObject startingLocationObject;
    public GameObject redFlag;
    public GameObject blueFlag;
    public NavMeshAgent agent;
    private AIState currentState;
    private Vector3 flagLocation;
    private Vector3 startingLocation;

    public enum AIState // DIFFERENT STATES FOR THE AI AGENT
    {
        MoveToFlagLocation,
        PickUpFlag,
        MoveToStartingLocation
    }

    void Start()
    {
        currentState = AIState.MoveToFlagLocation; //DEFINING THE STARTING STATE
        flagLocation = flagLocationObject.transform.position; // DEFINING THE POSITION FOR THE AI AGENST FLAG
        startingLocation = startingLocationObject.transform.position; // DEFINING THE STARTING LOCATION FOR THE AI AGENT
    }

    void Update()
    {
        switch (currentState) //SWICTHING BETWEEN THE DIFFERENT STATES OF THE AI AGENT
        {
            case AIState.MoveToFlagLocation:
                MoveToFlagLocation();
                break;
            case AIState.PickUpFlag:
                PickUpFlag();
                break;
            case AIState.MoveToStartingLocation:
               MoveToStartingLocation();
                break;

        }
    }

    private void MoveToFlagLocation() // MOVES THE AI AGENT TO ITS FLAG USING NAVMESH
    {
        agent.SetDestination(flagLocationObject.transform.position);

        
        if (agent.remainingDistance < 1f)
        {
            currentState = AIState.PickUpFlag; // SWICTHING TO THE NEXT STATE IN THE FINITE STATE MACHINE
        }
    }

    private void PickUpFlag() // SWITCHES TO THE NEXT STATE IF THE RED FLAG HAS BEEN PICKED UP
    {
        if (redFlag == null)
        {
            currentState = AIState.MoveToStartingLocation;

        }

       
        
    }

    private void OnTriggerEnter(Collider other) // CHECKS THE TAG OF THE FLAG ALLOWING THE AI AGENT TO PICK IT UP IF ITS THE CORRECT FLAG
    {
        if (other.CompareTag("Red Flag"))
        {
            redFlag = other.gameObject;
            Destroy(redFlag);
            currentState = AIState.PickUpFlag; // DEFINING THE CURRENT STATE TO ENSURE THE FLAG IS PICKED UP

        }



    }

    private void MoveToStartingLocation() // MOVES THE AI AGENT BACK TO ITS STARTING LOCATION USING THE NAVMESH
    {
        agent.SetDestination(startingLocationObject.transform.position);

        if (redFlag == null && agent.destination == startingLocationObject.transform.position)
        {
            SceneManager.LoadScene("Main");
        }

        if (blueFlag == null && player.transform.position == playerStartingLocation.transform.position )
        {
            SceneManager.LoadScene("Main");
        }
    }
}
