using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BalloonBehaviour : MonoBehaviour
{
    private static int _balloonsPopped = 0;

    public GameObject fingerPrefab;
    public Transform fingerSpawnPoint;
    
    private AudioSource _popSound;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        _popSound = GetComponentInParent<AudioSource>();
        fingerPrefab = Resources.Load<GameObject>("Prefabs/FingerPrefab");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            _popSound.Play();
            _balloonsPopped++;
            Debug.Log("Balloons popped: " + _balloonsPopped);
            if (_balloonsPopped == 5)
            {
                Debug.Log("FINGER SPAWNED");
                var finger = Instantiate(fingerPrefab, fingerSpawnPoint);
            }
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        Debug.Log("FINGER SPAWNED");
        var finger = Instantiate(fingerPrefab, fingerSpawnPoint);
    }
}
