using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObjectPool : MonoBehaviour
{
    public static BossObjectPool instance;
    private List<GameObject> bulletPool;
    private bool notEnoughBulletInPool = true;
    [SerializeField] private GameObject bulletPrefabs;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new List<GameObject>();
    }

    // Update is called once per frame
    public GameObject GetPooledObject()
    {
        if (bulletPool.Count > 0)
        {
            for (int i = 0; i < bulletPool.Count; i++)
            {
                if (!bulletPool[i].activeInHierarchy)
                    return bulletPool[i];
            }
        }
        if (notEnoughBulletInPool)
        {
            GameObject bullet = Instantiate(bulletPrefabs);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
            return bullet;
        }
        return null;
    }  
}
