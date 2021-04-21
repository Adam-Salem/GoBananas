using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class GameOver : MonoBehaviour
{
    public TMP_Text totalScore;
    public TMP_Text highScoreText;
    public TMP_Text newHighScore;
    private int scoreSum = 0;
    private int highScore;
    public AudioSource audio;

    void Start()
    {
        scoreSum = PlayerPrefs.GetInt("totalscore");
        highScore = PlayerPrefs.GetInt("highscore");
        totalScore.text = "" + scoreSum;
        if (scoreSum >= highScore){
            PlayerPrefs.SetInt("highscore", scoreSum);
            highScoreText.text = "" + scoreSum;
            newHighScore.text = "New High Score!";
        }else{
            highScoreText.text = "" + highScore;
        }
    }

    public void GoBack(){
        audio.Play();
        SceneManager.LoadScene("MainMenu");
    }

}
