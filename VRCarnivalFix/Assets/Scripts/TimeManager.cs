using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{

    [Header("Timer")]
    [SerializeField] private float countdown;
    [SerializeField] TextMeshProUGUI timeText;

    private bool disableTimer;

    public GameObject disableTimerObject;

    void Start()
    {
        disableTimer = true;
    }

    void Update()
    {
        if(disableTimer)
        {
        UpdateGameTimer();
        }

        CheckTime();
    }

    private void UpdateGameTimer()
    {
        countdown -= Time.deltaTime;

        var minutes = Mathf.FloorToInt(countdown / 60);
        var seconds = Mathf.FloorToInt(countdown - minutes * 60);

        string gameTimeClockDisplay = string.Format("{0:0}:{1:00}", minutes, seconds);

        timeText.text = gameTimeClockDisplay;

    }

    private void CheckTime()
    {
        if(countdown <= 0)
        {
            disableTimer = false;

            disableTimerObject.SetActive(false);
        }
    }
}
