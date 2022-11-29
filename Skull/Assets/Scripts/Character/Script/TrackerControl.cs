using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerControl : Controller
{
    GameObject target;
    protected float moveMinRange = 2;
    protected float moveMaxRange = 7;
    protected float lostRange = 10;
    protected float Distance { private set; get; }
    protected bool IsFind { private set; get; }

    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<PlayerControl>().gameObject;
    }

   

    protected virtual void Tracking()
    {
        bool isFall = true;
        bool isRightFall = Physics2D.Raycast(transform.position + new Vector3(transform.localScale.x, 0, 0), Vector2.down, 3).collider == null;
        bool isLeftFall = Physics2D.Raycast(transform.position - new Vector3(transform.localScale.x, 0, 0), Vector2.down, 3).collider == null;

        if ((target.transform.position.x - transform.position.x) > 0)
        {
            isFall = isLeftFall;
        }
        else
        {
            isFall = isRightFall;
        }
        isFall = isRightFall || isLeftFall;
        if (!isFall)
        {
            Move((target.transform.position.x - transform.position.x) / Mathf.Abs(target.transform.position.x - transform.position.x));
        }
    }

    protected virtual void Find()
    {
        Distance = Vector2.Distance(transform.position, target.transform.position);
        if (!IsFind && Distance < moveMaxRange)
        {
            IsFind = true;
        }
        if (IsFind && Distance > lostRange)
        {
            IsFind = false;
        }
    }
}
