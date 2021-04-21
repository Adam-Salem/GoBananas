using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public static bool paused = false;
    public GameObject pauseMenuUI;
    public AudioSource audio;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            if (paused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        audio.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause(){
        audio.Play();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void BackToMenu(){
        audio.Play();
        paused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit(){
        audio.Play();
        Application.Quit();
    }
}
