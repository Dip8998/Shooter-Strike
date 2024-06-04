using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] Text health;
    [SerializeField] GameObject deathPanel;

    private void Start()
    {
        deathPanel.gameObject.SetActive(false);
        health.text = SaveData.playerHealth + "%";
    }
    private void Update()
    {
        if(SaveData.HealthChanged == true)
        {
            SaveData.HealthChanged = false;
            health.text = SaveData.playerHealth + "%";
        }
        if(SaveData.playerHealth <= 0)
        {
            SaveData.playerHealth = 0;
            deathPanel.gameObject.SetActive(true);
            UnityEngine.Time.timeScale = 0f;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
                SaveData.HealthChanged = true;
                SaveData.playerHealth = 100;
                deathPanel.gameObject.SetActive(false);
                UnityEngine.Time.timeScale = 1f;
            }
            
        }

       
       
    }
    


}
