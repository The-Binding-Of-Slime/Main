using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAI : Mover
{
    GameObject target;
    float findRange = 2;
    float lostRange = 4;
    bool isFind;

    protected override void Start()
    {
        
    }

    
    void Update()
    {
        if(target == null)
        {
            FindTarget();
        }

        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (!isFind && findRange >= distance)
        {
            isFind = true;
        }else if(isFind && lostRange >= distance)
        {
            isFind=false;
        }

        bool isLeftRayHit = Physics2D.Raycast(transform.position + transform.localScale.x / 2 * Vector3.left, Vector2.down, 1f).collider != null;
        bool isRightRayHit = Physics2D.Raycast(transform.position + transform.localScale.x / 2 * Vector3.right,Vector2.down,1f).collider != null;
        if (isFind)
        {
            if (!isLeftRayHit && transform.position.x > target.transform.position.x)
            {
                Move(-3);
            }
            else if(!isRightRayHit && transform.position.x < target.transform.position.x)
            {
                Move(3);
            }
        }
    }

    void FindTarget()
    {
        target = FindObjectOfType<PlayerControl>().gameObject;
    }


}
