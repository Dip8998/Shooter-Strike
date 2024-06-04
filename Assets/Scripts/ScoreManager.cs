using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highScoreText;
    private int score = 0;
    public GameObject Panel;
    public AudioSource AudioSource;
    public AudioClip clip;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        UpdateScoreText();
        AudioSource.clip = clip;
        AudioSource.Play();

    }
    
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        HighScore();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        HighScore();
    }
    public void HighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }
    
}
