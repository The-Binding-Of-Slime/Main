using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAI : Mover
{
    [SerializeField]GameObject target;
    float findRange = 8;
    float lostRange = 12;
    [SerializeField]bool isFind;

    Animator animator;
    SpriteRenderer render;
    RangeAttacker attacker;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        attacker = GetComponent<RangeAttacker>();
        SetSpeed(1, 1);
    }

    
    void Update()
    {
        Debug.Log(attacker.AttackTimer);
        if(target == null)
        {
            FindTarget();
        }

        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (!isFind && findRange >= distance)
        {
            isFind = true;
        }else if(isFind && lostRange <= distance)
        {
            isFind=false;
        }

        bool isLeftRayHit = Physics2D.Raycast(transform.position + transform.localScale.x * new Vector3(1, -2, 0), Vector2.down, 1f).collider != null;
        bool isRightRayHit = Physics2D.Raycast(transform.position + transform.localScale.x * new Vector3(-1, -2, 0), Vector2.down,1f).collider != null;
        
        if (isFind)
        {
            if (attacker.AttackTimer > 0) {
                animator.SetBool("isRunning", false);
                return;
            }
            animator.SetBool("isRunning", true);
            if (isRightRayHit && transform.position.x > target.transform.position.x)
            {
                Move(-0.5f);
                render.flipX = true;
            }
            else if(isLeftRayHit && transform.position.x < target.transform.position.x)
            {
                Move(0.5f);
                render.flipX = false;
            }
            if(distance < 4)
            {
                attacker.UseAttack();
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        animator.SetBool("isGround", CheckIsGround());
    }

    void FindTarget()
    {
        target = FindObjectOfType<PlayerControl>().gameObject;
    }
}
