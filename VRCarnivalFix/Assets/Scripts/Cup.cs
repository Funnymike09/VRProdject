using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Cup : MonoBehaviour
{
    [Tooltip("If this cup contains ball")]public bool correctCup;
    [Tooltip("From left to right, the order the cups are displayed")]public int indexPos;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchPos(int animationType)
    {
        switch(animationType)
        {
            case 0: // Slide positive on x axis
                {
                    break;
                }
            case 1: // Slide negative on x axis
                {
                    break;
                }
            case 2: // Lifted on y axis
                {
                    break;
                }
            default: // if this runs im killing myself
                {
                    Debug.Log("PANIC!!!!! SwitchPos function in " + gameObject);
                    break;
                }
        }
    }
}
