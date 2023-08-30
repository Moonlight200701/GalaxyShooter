using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    int speed = 5;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().Damage();
            gameObject.SetActive(false);
        }
    }
    private void OnBecameInvisible()
    {
       gameObject.SetActive(false);
    }
}
