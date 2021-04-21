using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    public AudioSource audio;

    public void BackToMain(){
        audio.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
