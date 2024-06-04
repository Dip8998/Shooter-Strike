using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public int ScoreValue = 1;
    
    
   
    
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();// Access the camera with tag
        rb =  GetComponent<Rigidbody2D>();// Access the rigidbidy 2D component
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);// Applying the mouseInput
        Vector3 dir = mousePos - transform.position;// vector3 direction = Mouse Postion - Bullets Transform position
        Vector3  rotation = transform.position - mousePos;// vector3 rotation = transform position - mousePosition
        rb.velocity = new Vector2 (dir.x, dir.y) .normalized  * force;// apply velocity via rigidbody2D = vector2(dirction on xAxis, diraction on yAxis).normalized * force
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; 
        transform.rotation =  Quaternion.Euler(0,0,rot + 180);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            Destroy(collision.gameObject);
            ScoreManager.instance.IncreaseScore(ScoreValue);
            OnScreenScore.Instance.UpdateScreenScore();
            Destroy(gameObject);
        }
        

    }
}
