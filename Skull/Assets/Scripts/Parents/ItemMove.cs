using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    float time = 0;

    void Update ()
    {
        if(time < 2f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time / 2);
            time += Time.deltaTime;
        }
    }
}
