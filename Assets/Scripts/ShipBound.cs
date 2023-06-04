using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBound : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minX = -bounds.x;
        maxX = bounds.x;
        minY = -bounds.y;
        maxY = bounds.y;
        Debug.Log(bounds);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = transform.position;
        if (temp.x < minX + 0.3)
        {
            temp.x = (float)(minX + 0.3);
        }
        else if (temp.x > maxX-0.3)
        {
            temp.x = (float)(maxX - 0.3);
        }
        if (temp.y < minY+0.3)
        {
            temp.y = (float)(minY + 0.3);
        }
        else if (temp.y > maxY-0.3)
        {
            temp.y = (float)(maxY - 0.3);
        }

        transform.position = temp;
        Debug.Log("temp is" + temp);




    }
}

