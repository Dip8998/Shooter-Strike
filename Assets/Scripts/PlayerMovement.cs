using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private GameObject bullet;
    public Transform bulletPos;
    public float moveSpeed;
    Vector2 moveDirection;
    Vector2 mousePosition;
    float xMove;
    float yMove;
    private bool _canFire;
    private float _timer;
    public  float _timeBetweenFiring; 
    private AudioSource _source;
    public AudioClip _clip;
    private Rigidbody2D  _rb;
    private float nextFireTime = 0f;


    void Start()
    {
        
        _source = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {
       if(SaveData.playerHealth > 0)
        {
            //transform.position = new Vector2(Mathf.Clamp(transform.position.x, -10, 10), Mathf.Clamp(transform.position.y, -6, 6));

           // xMove = Input.GetAxis("Horizontal") * UnityEngine.Time.deltaTime * moveSpeed;
            //yMove = Input.GetAxis("Vertical") * UnityEngine.Time.deltaTime * moveSpeed;

            if (!_canFire)
            {
                _timer += UnityEngine.Time.deltaTime;
                if (_timer > _timeBetweenFiring)
                {
                    _canFire = true;
                    _timer = 0;

                }
            }

            if (Input.GetMouseButton(0) && _canFire && UnityEngine.Time.time >= nextFireTime)
            {
                GameObject obj = Instantiate(bullet, bulletPos.position, Quaternion.identity);
                //_source.clip = _clip;
                _source.PlayOneShot(_clip);
                _canFire = false;
                Destroy(obj, 3f);
                nextFireTime = UnityEngine.Time.time + _timeBetweenFiring;
            }

            moveDirection = new Vector2(xMove, yMove);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
        
    private void FixedUpdate()
    {
        //_rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        Vector2 aimDir = mousePosition - _rb.position;
        float rot = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg ;
        _rb.rotation = rot;
    }

}
