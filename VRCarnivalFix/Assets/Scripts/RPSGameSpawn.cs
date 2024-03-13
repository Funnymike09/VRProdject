using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSGameSpawn : MonoBehaviour
{

    [SerializeField] GameObject[] objects;

    GameObject spawnedObject;

    Vector3 position;

    void Update()
    {
        
    }

    public void Spawn()
    {
        int rpsObjectID = Random.Range(0,objects.Length);

        position = new Vector3(32,10,4);

        spawnedObject = Instantiate(objects[rpsObjectID], position, Quaternion.identity) as GameObject;
    }
}
