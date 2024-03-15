using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private float originalCountdown;
    [SerializeField] TextMeshProUGUI timeText;

    private float countdown;
    private bool disableTimer;

    public GameObject disableTimerObject;

    void Start()
    {
        countdown = originalCountdown;
        disableTimer = true;
        UpdateGameTimer();
    }

    void Update()
    {
        if (disableTimer)
        {
            UpdateGameTimer();
        }
        CheckTime();
    }

    private void UpdateGameTimer()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            countdown = 0;
        }

        var minutes = Mathf.FloorToInt(countdown / 60);
        var seconds = Mathf.FloorToInt(countdown - minutes * 60);

        string gameTimeClockDisplay = string.Format("{0:0}:{1:00}", minutes, seconds);

        timeText.text = gameTimeClockDisplay;
    }

    private void CheckTime()
    {
        if (countdown <= 0)
        {
            disableTimer = false;
            disableTimerObject.SetActive(false);
        }
    }

    public void ResetTimer()
    {
        countdown = originalCountdown;
        disableTimer = true;
        UpdateGameTimer();
    }
}