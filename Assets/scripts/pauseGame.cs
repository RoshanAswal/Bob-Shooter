using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour
{
    public bool gamePaused=false;
    public GameObject pausePanel;
    public Button playpause;
    public Sprite playImg;
    public Sprite pauseImg;
    private void Update() {
        if(gamePaused){
            Time.timeScale=0f;
        }
    }
    public void onPause(){
        gamePaused=true;
        pausePanel.SetActive(true);
        playpause.image.sprite=playImg;
    }
    public void Resume(){
        gamePaused=false;
        pausePanel.SetActive(false);
        playpause.image.sprite=pauseImg;
    }
    public void Ending(){
        Application.Quit();
    }
    public void restart(){
        SceneManager.LoadScene("Level 1");
    }
}
