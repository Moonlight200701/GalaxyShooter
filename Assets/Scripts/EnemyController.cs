using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject bullet,explosion,Bonus;
    public int score;
    public float xSpeed;
    public float ySpeed;
    public bool canshoot;
    public float firerate;
    public float health = 2;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    } 
    // Start is called before the first frame update
    void Start()
    {
        if (canshoot)
        {
            InvokeRepeating("Shoot", firerate, firerate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed,ySpeed*-1);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage();
            Destroy(gameObject);
            Instantiate(explosion,transform.position,Quaternion.identity);
        }
       
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (Random.Range(0, 8) == 0)
        {
            Instantiate(Bonus,transform.position,Quaternion.identity);  
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
        PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+score); //add score to current score

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
