using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : Controller
{
    GameObject target;
    float moveMinRange = 2;
    float moveMaxRange = 7;
    bool isFind;
    bool isRightFall;
    bool isLeftFall;

    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<PlayerControl>().gameObject;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (!isFind && distance < moveMaxRange)
        {
            isFind = true;
        }
        if(isFind && distance > moveMinRange)
        {
            bool isFall = true;
            isRightFall = Physics2D.Raycast(transform.position + new Vector3(transform.localScale.x, 0, 0), Vector2.down, 3).collider == null;
            isLeftFall = Physics2D.Raycast(transform.position - new Vector3(transform.localScale.x,0,0), Vector2.down, 3).collider == null;
            
            if ((target.transform.position.x - transform.position.x) > 0) {
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
        if(isFind && distance <= moveMinRange)
        {
            UseAttack(0);
        }
    }

    protected virtual void FixedUpdate()
    {

    }
}
