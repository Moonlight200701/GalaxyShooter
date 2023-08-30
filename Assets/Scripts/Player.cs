using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject ShipTurret;
    public GameObject bullet,explosion;
    public int health = 3;
    public Rigidbody2D rb;
    public float speed;
    private Vector2 moveInput;
    [SerializeField] public Transform bulletPosition;
    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        ShipTurret = transform.Find("ShipTurret").gameObject;
    }
    private void Start()
    {
        PlayerPrefs.SetInt("Health", health);
    }

    // Update is called once per frame
    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * speed;

    }

    
    public void TakeDamage()
    {
        health--;
        StartCoroutine(Blink());
        PlayerPrefs.SetInt("Health", health);
        if (health == 0)
        {
            Destroy(gameObject);
            Instantiate(explosion,transform.position, Quaternion.identity); 
        }
    }

    private IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 1 );
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    public void AddHealth()
    {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }
}
