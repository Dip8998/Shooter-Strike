using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    public GameObject healObj;
    public float Speed;
    private float dis;
    public float rotateSpeed;
    public  int damage = 10;
    private bool HitActive = false;
    private int Score;

    private void Update()
    {
        healObj = GameObject.FindGameObjectWithTag("Heal");
        if (!Player)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsPlayer();
        }
        

        transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * UnityEngine.Time.deltaTime);   
    }
    public void GetTarget()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    public void RotateTowardsPlayer()
    {
        Vector2 targetDir = Player.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;

        Quaternion q = Quaternion.Euler(new Vector3 (0,0,angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!HitActive)
            {
                Debug.Log("Player hit by enemy.");
                HitActive = true;
                SaveData.playerHealth -= damage;
                SaveData.HealthChanged = true;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (HitActive == true)
            {
                HitActive = false;
            }
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Score++;
           GameObject obj = Instantiate(healObj,transform.position, Quaternion.identity);
        }
    }
}
