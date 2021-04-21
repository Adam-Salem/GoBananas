using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public AudioSource audio;

    void Start(){
        PlayerPrefs.SetInt("totalscore", 0);
    }

    public void PlayGame(){
        audio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        audio.Play();
        Application.Quit();
    }

    public void Credits(){
        audio.Play();
        SceneManager.LoadScene("Credits");
    }

    [SerializeField] Slider volumeSlider;
    private void Awake(){
        if (PlayerPrefs.HasKey("Volume")){
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }else{
            PlayerPrefs.SetFloat("Volume", 1f);
        }
    }

    public void SetVolume(float volume){
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
