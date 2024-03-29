using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> poolObjects = new List<GameObject>();
    private int amountToPool = 40;
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
       for(int i = 0; i < amountToPool; i++) 
        {
            GameObject obj = Instantiate(bulletPrefabs);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }
    }

    // Update is called once per frame
    public GameObject GetPooledObject()
    {
        for (int i = 0;i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
                return poolObjects[i];
        }
        return null;
    }
}
