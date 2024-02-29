using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Cup : MonoBehaviour
{
    [Tooltip("If this cup contains ball")]public bool correctCup;
    [Tooltip("From left to right, the order the cups are displayed")]public int indexPos;
    public Animator animator;
    private CupMinigame cupMinigame;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        cupMinigame = FindObjectOfType<CupMinigame>();
    }

    //MidToRight = animNum 0
    //MidToLeft = animNum 1
    //LeftToMid = animNum 2
    //LeftToRight = animNum 3
    //RightToLeft = animNum 4
    //RightToMid = animNum 5

    public void SwitchPos(int target)
    {
        switch(target)
        {
            case 0: // TARGET LEFT
                {
                    switch (indexPos)
                    {
                        case 0: // SAMESIES
                            {
                                UpdateCupMinigame();
                                Debug.Log("TARGET AND INDEX THE SAME IN CUP " + gameObject.name);
                                break;
                            }
                        case 1: // MID TO LEFT
                            {
                                animator.SetInteger("animNum", 1);
                                animator.SetTrigger("advance");
                                break;
                            }
                        case 2: // RIGHT TO LEFT
                            {
                                animator.SetInteger("animNum", 4);
                                animator.SetTrigger("advance");
                                break;
                            }
                        default: // help
                            {
                                Debug.Log("PANIK IN CASE 0 SWITCH STATEMENT IN SWITCHPOS IN CUP " + gameObject.name);
                                break;
                            }
                    }
                    break;
                }
            case 1: // TARGET MID
                {
                    switch (indexPos)
                    {
                        case 0: // LEFT TO MID
                            {
                                animator.SetInteger("animNum", 2);
                                animator.SetTrigger("advance");
                                break;
                            }
                        case 1: // SAMESIES
                            {
                                UpdateCupMinigame();
                                Debug.Log("TARGET AND INDEX THE SAME IN CUP " + gameObject.name);
                                break;
                            }
                        case 2: // RIGHT TO MID
                            {
                                animator.SetInteger("animNum", 5);
                                animator.SetTrigger("advance");
                                break;
                            }
                        default: // dont do it
                            {
                                Debug.Log("PANIK IN CASE 1 SWITCH STATEMENT IN SWITCHPOS IN CUP " + gameObject.name);
                                break;
                            }
                    }
                    break;
                }
            case 2: // TARGET RIGHT
                {
                    switch (indexPos)
                    {
                        case 0: // LEFT TO RIGHT 
                            {
                                animator.SetInteger("animNum", 3);
                                animator.SetTrigger("advance");
                                break;
                            }
                        case 1: // MID TO RIGHT
                            {
                                animator.SetInteger("animNum", 0);
                                animator.SetTrigger("advance");
                                break;
                            }
                        case 2: // SAMESIES
                            {
                                UpdateCupMinigame();
                                Debug.Log("TARGET AND INDEX THE SAME IN CUP " + gameObject.name);
                                break;
                            }
                        default: // please dont run
                            {
                                Debug.Log("PANIK IN CASE 2 SWITCH STATEMENT IN SWITCHPOS IN CUP " + gameObject.name);
                                break;
                            }
                    }
                    break;
                }
            default: // if this runs im killing myself
                {
                    Debug.Log("PANIC!!!!! SwitchPos function in " + gameObject);
                    break;
                }
        }
    }

    private void UpdateCupMinigame()
    {
        cupMinigame.CompletedAnimation();
    }

    private void UpdateIndex(int currentIndex)
    {
        this.indexPos = currentIndex;
    }
}
