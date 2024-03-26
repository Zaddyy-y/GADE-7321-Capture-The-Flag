using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlag : MonoBehaviour
{
    public GameObject spawnFlag;
    public Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;
        Instantiate(spawnFlag, spawnPoint, Quaternion.identity);
    }

    
    void Update()
    {
        
    }
}
