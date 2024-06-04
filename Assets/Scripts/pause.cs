using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject pausePanel;
   
    public void Pause()
    {
        UnityEngine.Time.timeScale = 0f;
        pausePanel.SetActive(true);
        
        

    }
    public void Resume()
    {
        pausePanel.SetActive(false);    
        UnityEngine.Time.timeScale = 1f;
    }
    public void Restart()
    { 
        pausePanel.SetActive(false);
        SceneManager.LoadScene(1);
        UnityEngine.Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
       

    }
}
