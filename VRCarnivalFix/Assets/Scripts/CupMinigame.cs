using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CupMinigame : MonoBehaviour
{
    [SerializeField] private Cup[] cups;
    [SerializeField] private GameObject ball;
    [Tooltip("The starting positions of the cups")][SerializeField] private Transform[] baseTransforms; // This should be able to scale exponentially
    [SerializeField] private float speedMultiplier;

    void Start()
    {
        baseTransforms = new Transform[cups.Length];
        for (int i = 0; i < cups.Length; i++)
        {
            baseTransforms[i] = cups[i].transform;
        }

    }

    void Update()
    {
        
    }
}
