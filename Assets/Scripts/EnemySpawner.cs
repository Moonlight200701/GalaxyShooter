using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float rate;
    public GameObject [] Enemies;
    [SerializeField]
    private float timespawninterval;
    void Start()
    {
        StartCoroutine(SpawnEnemy(timespawninterval,Enemies));
    }

    // Update is called once per frame
    private IEnumerator SpawnEnemy(float interval, GameObject[]enemies)
    {
       yield return new WaitForSeconds(timespawninterval);
       GameObject newEnemy = Instantiate(Enemies[Random.Range(0, Enemies.Length)], new Vector3(Random.Range(-6.0f, 6.0f), 4, 0), Quaternion.identity);
       StartCoroutine(SpawnEnemy(interval, enemies));
    }
}
