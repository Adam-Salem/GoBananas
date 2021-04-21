using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreControl : MonoBehaviour
{
    public TMP_Text scoreCounter;
    private int scores;


    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject thePlayer = GameObject.Find("Player");
        PlayerController player = thePlayer.GetComponent<PlayerController>();
        scores = player.score;
        scoreCounter.text = "" + scores;
    }
}
