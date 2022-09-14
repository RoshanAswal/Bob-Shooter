using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void Awake() {
        FindObjectOfType<AudioManager>().Stop("main");
    }
    public void Next(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void End(){
        Application.Quit();
    }
}
