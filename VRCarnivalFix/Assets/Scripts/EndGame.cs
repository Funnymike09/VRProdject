using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public RockPaperScissors rps;
    public CupMinigame cup;
    public BalloonBehaviour dart;

    public GameObject curtain, blackBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rps.rpsMinigameWon && cup.cupMinigameWon && dart.dartMinigameWon) 
        {
            curtain.SetActive(false);
            blackBox.SetActive(false);
        }
    }
}
