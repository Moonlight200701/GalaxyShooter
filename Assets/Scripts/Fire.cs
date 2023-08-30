using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public float attackInterval;
    private float shotCounter;
    [SerializeField] private Transform bulletPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
       if(shotCounter > 0)
        {
            shotCounter-= Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = ObjectPool.instance.GetPooledObject();
            /*Instantiate(bullet, transform.position, Quaternion.identity);*/
            if(bullet != null)
            {
                bullet.transform.position = bulletPosition.position;
                bullet.SetActive(true);
            }
            AudioManager.instance.PlaySFX(0);
            shotCounter = attackInterval;
        }
        
    }
    
}
