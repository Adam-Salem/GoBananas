using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class HealthControl : MonoBehaviour
{
    public TMP_Text healthCounter;
    private int healths;

    // Start is called before the first frame update
    void Start()
    {
        healthCounter = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject thePlayer = GameObject.Find("Player");
        PlayerController player = thePlayer.GetComponent<PlayerController>();
        healths = player.health;
        healthCounter.text = "" + healths;
    }
}
