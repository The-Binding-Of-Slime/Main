using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [SerializeField]GameObject target;
    float findRange = 6;
    float lostRange = 8;
    bool isFind;

    Animator animator;
    SpriteRenderer render;
    Mover mover;
    Attacker attacker;

    protected void Start()
    {
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
        mover.SetSpeed(1, 1);
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

        bool isLeftRayHit = Physics2D.Raycast(transform.position + transform.localScale.x / 2 * new Vector3(1, -2, 0), Vector2.down, 1f).collider != null;
        bool isRightRayHit = Physics2D.Raycast(transform.position + transform.localScale.x / 2 * new Vector3(-1, -2, 0), Vector2.down,1f).collider != null;
        
        if (isFind)
        {
            if (isRightRayHit && transform.position.x > target.transform.position.x)
            {
                mover.Move(-0.5f);
            }
            else if(isLeftRayHit && transform.position.x < target.transform.position.x)
            {
                mover.Move(0.5f);
            }
            if(distance < 2)
            {
                
            }
        }
    }

    void FindTarget()
    {
        target = FindObjectOfType<PlayerControl>().gameObject;
    }
}
