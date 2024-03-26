using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class FSM : MonoBehaviour
{
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

    public enum AIState
    {
        MoveToFlagLocation,
        PickUpFlag,
        MoveToStartingLocation
    }

    void Start()
    {
        currentState = AIState.MoveToFlagLocation;
        flagLocation = flagLocationObject.transform.position;
        startingLocation = startingLocationObject.transform.position;
    }

    void Update()
    {
        switch (currentState)
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

    private void MoveToFlagLocation()
    {
        agent.SetDestination(flagLocationObject.transform.position);

        
        if (agent.remainingDistance < 1f)
        {
            currentState = AIState.PickUpFlag;
        }
    }

    private void PickUpFlag()
    {
        if (redFlag == null)
        {
            currentState = AIState.MoveToStartingLocation;

        }

       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red Flag"))
        {
            redFlag = other.gameObject;
            Destroy(redFlag);
            currentState = AIState.PickUpFlag;

        }



    }

    private void MoveToStartingLocation()
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