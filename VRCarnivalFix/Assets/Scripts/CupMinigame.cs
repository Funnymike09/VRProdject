using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class CupMinigame : MonoBehaviour
{
    [SerializeField] private Cup[] cups;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject thumbPrefab;
    [SerializeField] private GameObject button;
    [Tooltip("The starting positions of the cups")][SerializeField] private Transform[] baseTransforms; // This should be able to scale exponentially
    private float speedMultiplier;
    [SerializeField] private float speedIncrement;
    [SerializeField] private int timesToSwitch;
    private int timesSwitched;
    [SerializeField] private float timeBetweenSwitches;
    private bool finished;
    private GameObject ball;
    private GameObject thumb;

    void Start()
    {
        speedMultiplier = 1;
        baseTransforms = new Transform[cups.Length];
        for (int i = 0; i < cups.Length; i++)
        {
            baseTransforms[i] = cups[i].transform;
            cups[i].animator.SetFloat("speedMultiplier", speedMultiplier);
            if (i == 1) // THIS WILL ONLY WORK WIF 3 CUPS 
            {
                ball = Instantiate(ballPrefab);
                SetBallPos(cups[i].transform.position);
                cups[i].correctCup = true;
            }
        }
        //StartMinigame(); // PROBABLY WANT THIS COMMENTED OUT IN THE FINAL BUILD
    }

    private void SetBallPos(Vector3 cupPos)
    {
        ball.SetActive(true);
        float ballY = cupPos.y - .15f;
        ball.transform.position = new Vector3(cupPos.x, ballY, cupPos.z);
    }

    public void SwitchCups()
    {
        if (ball.GameObject().activeSelf)
        {
            ball.SetActive(false);
        }
        if (!finished)
        {
            List<int> randomNums = GenerateOrder();

            for (int i = 0; i < cups.Length; i++)
            {
                cups[i].animator.SetFloat("speedMultiplier", speedMultiplier + speedIncrement);
                cups[i].SwitchPos(randomNums[i]);
            }
        }
    }

    [HideInInspector] public int gyatt = 0;

    public void CompletedAnimation() // ADD EVENT IN ANIMATION
    {
        gyatt++;
        if (gyatt >= 3)
        {
            //Debug.Log("gyatt = 3");
            gyatt = 0;
            timesSwitched++;
            speedMultiplier += speedIncrement;

            if (timesSwitched >= timesToSwitch)
            {
                Debug.Log("FINISHED");
                finished = true;
                for (int i = 0; i < 3; i++)
                {
                    cups[i].grabInteractable.enabled = true;
                    if (cups[i].correctCup)
                    {
                        SetBallPos(cups[i].transform.position);
                        i = 3;
                    }
                }
                // STOP ANIMATING, LET PLAYER CHOOSE

            }

            if (!finished)
            {
                StartCoroutine(WaitFor(timeBetweenSwitches));
                SwitchCups();
            }
        }
    }

    IEnumerator WaitFor(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
    }

    private List<int> GenerateOrder()
    {
        System.Random random = new System.Random();
        HashSet<int> candidates = new HashSet<int>();
        for (int i = 0; i < 3; i++)
        {
            if (!candidates.Add(random.Next(0, i + 1)))
            {
                candidates.Add(i);
            }
        }

        List<int> result = candidates.ToList();

        for (int i = 0; i < result.Count; i++)
        {
            int k = random.Next(i + 1);
            int tmp = result[k];
            result[k] = result[i];
            result[i] = tmp;
        }

        return result;
    }

    public void StartMinigame()
    {
        for (int i = 0; i < 3; i++)
        {
            if (cups[i].correctCup)
            {
                cups[i].animator.SetTrigger("correctCupAdvance");
                i = 3;
            }
        }
        StartCoroutine(WaitFor(3f));
        //SwitchCups(); THIS WILL NOW BE AN EVENT ON THE CUP LIFT ANIMATION
    }

    public void CorrectCupPicked()
    {
        Vector3 ballPos = ball.transform.position;
        Destroy(ball.gameObject);
        thumb = Instantiate(thumbPrefab);
        thumb.transform.position = ballPos;
        // WHATEVA THA FUCK BEHAVIOUR WE WANT HERE
    }

    public void IncorrectCupPicked()
    {
        // SAME AS ABOVE
        StartCoroutine(WaitFor(2f));
        for (int i = 0; i < 3; i++)
        {
            if (cups[i].correctCup)
            {
                cups[i].animator.SetTrigger("correctCupAdvance");
            }
        }
        StartCoroutine(WaitFor(2f));
        ResetMinigame();
    }

    public void ResetMinigame()
    {
        button.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            cups[i].transform.position = baseTransforms[i].position;
            if (cups[i].correctCup)
            {
                SetBallPos(cups[i].transform.position);
            }
        }
        ball.SetActive(true);
        gyatt = 0;
        speedMultiplier = 1;
        timesSwitched = 0;
        finished = false;
    }
}
