using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip clip;
    public void Start()
    {
        AudioSource.clip = clip;
        AudioSource.Play();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
