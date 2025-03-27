using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private float penaltyTime;
    
    private bool timeRunning = false;
    private float time;

    private void Start()
    {
        timer.text = "";
    }

    private void Update()
    {
        if (timeRunning)
        {
            time += Time.deltaTime;
            timer.text = "Time: " + time;
        }
    }

    private void Penalty()
    {
        time += penaltyTime;
    }

    private void StartRace()
    {
        timeRunning = true;
    }

    private void EndRace()
    {
        timeRunning = false;
    }

    private void OnEnable()
    {
        GameEvents.startRace += StartRace;
        GameEvents.racePenalty += Penalty;
        GameEvents.raceEnd += EndRace;
    }

    private void OnDisable()
    {
        GameEvents.startRace -= StartRace;
        GameEvents.racePenalty -= Penalty;
        GameEvents.raceEnd -= EndRace;
    }
}
