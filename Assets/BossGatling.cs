using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossGatling : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 50;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    private void Start()
    {
        InvokeRepeating("BossFire", 0f, 2f);
    }

    private void BossFire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector3 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BossObjectPool.instance.GetPooledObject();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BossBullet>().SetDirection(bulDir);

            angle += angleStep;
                               

        }
    }
}


