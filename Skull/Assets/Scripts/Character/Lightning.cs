using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : HitBox
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(FindObjectOfType<PlayerControl>() != null)
        {
            transform.position = FindObjectOfType<PlayerControl>().transform.position;
        }
    }
}
