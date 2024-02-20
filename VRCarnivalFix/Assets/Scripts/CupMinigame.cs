using Unity.VisualScripting;
using UnityEngine;

public class CupMinigame : MonoBehaviour
{
    [SerializeField] private Cup[] cups;
    [SerializeField] private GameObject ball;
    [Tooltip("The starting positions of the cups")][SerializeField] private Transform[] baseTransforms; // This should be able to scale exponentially
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float speedIncrement;
    [SerializeField] private int timesToSwitch;
    private int timesSwitched;

    void Start()
    {
        baseTransforms = new Transform[cups.Length];
        for (int i = 0; i < cups.Length; i++)
        {
            baseTransforms[i] = cups[i].transform;
            cups[i].animator.SetFloat("speedMultiplier", speedMultiplier);
            if (i == 1) // THIS WILL ONLY WORK WIF 3 CUPS 
            {
                cups[i].correctCup = true;
            }
        }

    }

    void Update()
    {
        
    }

    void SwitchCups()
    {
        int[] integers = new int[cups.Length];
        for (int i = 0; i < integers.Length; i++)
        {
            integers[i] = Random.Range(0, 3);
        }
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].animator.SetFloat("speedMultiplier", speedMultiplier + speedIncrement);
            cups[i].SwitchPos(integers[i]);
        }

        timesSwitched++;

        if (timesSwitched >=  timesToSwitch)
        {
            // STOP ANIMATING, LET PLAYER CHOOSE
        }
    }

    public int gyatt = 0;

    void CompletedAnimation() // ADD EVENT IN ANIMATION
    {
        gyatt++;
        if (gyatt <= 3)
        {
            gyatt = 0;
            SwitchCups();
        }
    }
}
