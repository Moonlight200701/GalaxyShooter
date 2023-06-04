using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float time;
    public GameObject explosion;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(explosion,time);
    }

    // Update is called once per frame
   
    
}
