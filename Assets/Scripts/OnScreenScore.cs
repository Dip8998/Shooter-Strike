using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnScreenScore : MonoBehaviour
{
    public static OnScreenScore Instance;
    public Text scoreText;
    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        scoreText.text = score.ToString();
    }
    public void UpdateScreenScore()
    {
        // increment the score while playing
        score++;
        scoreText.text = score.ToString();
    }
   
}
