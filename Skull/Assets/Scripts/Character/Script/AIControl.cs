using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : Controller
{
    GameObject target;
    float moveMinRange = 2;
    float moveMaxRange = 7;
    bool isFind;

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
            Move((target.transform.position.x - transform.position.x) / Mathf.Abs(target.transform.position.x - transform.position.x));
        }
        if(isFind && distance <= moveMinRange)
        {
            UseAttack(0);
        }
    }
}
