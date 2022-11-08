using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAI : Mover
{
    [SerializeField]GameObject target;
    float findRange = 6;
    float lostRange = 8;
    bool isFind;

    Animator animator;
    SpriteRenderer render;
    Attacker attacker;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        attacker = GetComponent<Attacker>();
        SetSpeed(1, 1);
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
            if(distance < 2)
            {
                attacker.useAttack();
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
