using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlag : MonoBehaviour
{
    //VARIABLES
    public GameObject spawnFlag;
    public Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;
        Instantiate(spawnFlag, spawnPoint, Quaternion.identity); //SPAWNS FLAGS AT THEIR RESPECTIVE POSITIONS
    }

    
    void Update()
    {
        
    }
}
