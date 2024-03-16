using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Linq;

public class RockPaperScissors : MonoBehaviour
{

    // enum to manage choices
    public enum RPS 
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,
        None = 4,

    }

    public RPS aiChoice, playerChoice;

    private Animator _animator;

    public GameObject playButton, fingerPrefab;

    public Transform fingerSpawnPoint;

    public ParticleSystem particle;

    public AudioSource winAudio;

    public bool rpsMinigameWon = false;

    public void RPSInit() 
    {
        //gets a random value from the enum to be the ai's choice (this is kind of overly complex but i think its best way to do it)

        var values = Enum.GetValues(typeof(RPS));

        System.Random random = new System.Random();

        RPS randomRPS = (RPS)values.GetValue(random.Next(values.Length - 1));

        aiChoice = randomRPS;

        playButton.SetActive(false);

        playAnimation();
    }

    public void playAnimation() 
    {
        //plays an anim based on the ai's choice and then queues up the comparison function call

        switch(aiChoice) {
            case RPS.Rock:

            _animator.Play("RockBent");
            Invoke("CompareGestures", 3.5f);

                break;

            case RPS.Paper:

            _animator.Play("PaperBendy");
            Invoke("CompareGestures", 3.5f);

                break;

            case RPS.Scissors:

            _animator.Play("ScissorsBendy2");
            Invoke("CompareGestures", 3.5f);

                break;

            default:

                break;
        }

    }

    public void CompareGestures() 
    {
        //checks for win permutations and calls the win function if so

        if (aiChoice == RPS.Rock && playerChoice == RPS.Paper) {
            WinGame();
        }

        else if (aiChoice == RPS.Paper && playerChoice == RPS.Scissors) {
            WinGame();
        }
            
        else if (aiChoice == RPS.Scissors && playerChoice == RPS.Rock) {
            WinGame();
        }
        
        else LoseGame();
            
    }

    public void WinGame() 
    {
        Instantiate(fingerPrefab, fingerSpawnPoint);
        winAudio.Play();
        particle.Play();
        rpsMinigameWon = true;
    }

    public void LoseGame() 
    {
        playButton.SetActive(true);
    }

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        fingerPrefab = Resources.Load<GameObject>("Prefabs/MiddleL");
    }

    void Update()
    {
        //debug
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            RPSInit();
        }

        if (Input.GetKeyDown(KeyCode.K)) 
        {
            SetState("Rock");
        }

    }

    public void SetState(string newState) 
    {
        //used to grab the playeres choice from a string input called when they make the gesture in game
        playerChoice = (RPS) Enum.Parse(typeof(RPS), newState);
    }
}
