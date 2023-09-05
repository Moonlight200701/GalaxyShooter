using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }
    private void Start()
    {
        moveSpeed = 5f;
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

    }
    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage();
            gameObject.SetActive(false);
        }
    }
}
