using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpsAnimationSelecter : MonoBehaviour
{
    public GameObject[] targetGameObjects;
    public Animator animator;

    public string[] animationStateNames = new string[3] { "AnimationState1", "AnimationState2", "AnimationState3" };

    private void Update()
    {
        for (int i = 0; i < targetGameObjects.Length; i++)
        {
            if (targetGameObjects[i].activeInHierarchy)
            {
                if (animator != null && !string.IsNullOrEmpty(animationStateNames[i]))
                {
                    animator.Play(animationStateNames[i]);
                }
                break;
            }
        }
    }
}