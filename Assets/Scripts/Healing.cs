using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public int heal = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if(SaveData.playerHealth < 100)
            {
                Destroy(gameObject);
                SaveData.playerHealth += heal;
            }
            
           
        }
    }
}
