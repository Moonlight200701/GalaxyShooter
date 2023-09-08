using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private float moveSpeed;
    private bool moveToRight;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1f;
        moveToRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 2f)
        {
            moveToRight = false;
        }
        if(transform.position.x < -2f)
        {
            moveToRight = true;
        }

        if (moveToRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage();
        }
    }
}
