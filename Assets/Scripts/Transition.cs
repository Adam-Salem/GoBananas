using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class Transition : MonoBehaviour
{
    public TMP_Text totalScore;
    private int scoreSum = 0;
    public AudioSource audio;

    void Start()
    {
        scoreSum = PlayerPrefs.GetInt("totalscore");
        totalScore.text = "" + scoreSum;
    }

    public void Next(){
        audio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
