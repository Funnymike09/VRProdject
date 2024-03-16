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
    
    [SerializeField] private AudioSource _popSound;
    [SerializeField] private AudioSource _winSound;

    public ParticleSystem particle;

    public bool dartMinigameWon = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        fingerPrefab = Resources.Load<GameObject>("Prefabs/FingerPrefab");
        _popSound = GetComponent<AudioSource>();
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
                _winSound.Play();
                particle.Play();
                dartMinigameWon = true;
            }
            Destroy(gameObject);
            
        }
    }
    
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        Debug.Log("FINGER SPAWNED");
        var finger = Instantiate(fingerPrefab, fingerSpawnPoint);
        _winSound.Play();
        particle.Play();
    }
}
