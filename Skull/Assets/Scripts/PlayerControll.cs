using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : Attackable
{
    PlayerInput inputSys;
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer render;
    public float moveSpeed;
    public float jumpPower;
    public float statDamage;
    public float statHp;
    public float statSpeed;
    public float statAttackDelay;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        inputSys = FindObjectOfType<PlayerInput>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        RefreshStat();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position + Vector3.down * 0.9f, Vector2.down, 0.4f);
        bool ishit = hit.collider != null && !hit.collider.isTrigger;
        if(ishit && inputSys.GetJumpDown)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
            animator.SetBool("isJump", true);
        }

        if (ishit && !animator.GetBool("isGround"))
        {
            animator.SetBool("isJump", false);
        }

        if (ishit)
        {
            animator.SetBool("isGround", true);
        }
        else
        {
            animator.SetBool("isGround", false);
        }

        if (inputSys.Hor > 0f)
        {
            render.flipX = false;
        }
        else if(inputSys.Hor < 0f)
        {
            render.flipX = true;
        }

        if(!inputSys.GetHorDown)
        {
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
        }
        if (inputSys.GetInteractionDown)
        {
            interactionCheck();
        }
    }

    private void FixedUpdate()
    {
        if (inputSys.GetHorDown && Mathf.Abs(rigid.velocity.x) < moveSpeed)
        {
            rigid.AddForce(new Vector2(inputSys.Hor, 0f) * moveSpeed * 30);
        }
    }

   /* private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<Interaction>() != null && inputSys.GetInteractionDown)
        {
            Transform go = collision.transform;
            while(go.GetComponentInParent<Interaction>() != null && go.GetComponent<Interaction>() == null)
            {
                go = go.parent;
            }
            Interaction[] inters = go.GetComponents<Interaction>();
            foreach(Interaction inter in inters)
            {
                inter.interaction();
            }
            //gameObject.SetActive(false);
        }
    }*/

    void interactionCheck()
    {
        Collider2D[] collisions = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1),0);
        foreach (Collider2D collision in collisions)
        {
            if (collision.GetComponentInParent<Interaction>() != null)
            {
                Transform go = collision.transform;
                while (go.GetComponentInParent<Interaction>() != null && go.GetComponent<Interaction>() == null)
                {
                    go = go.parent;
                }
                Interaction[] inters = go.GetComponents<Interaction>();
                foreach (Interaction inter in inters)
                {
                    inter.interaction();
                }
                //gameObject.SetActive(false);
            }
        }
    }

    public void initStat(float attack, float hp, float speed, float Delay)
    {
        attackDamage = attack;
        maxHp = hp;
        moveSpeed = speed;
        attackDelay = Delay;
    }

    void RefreshStat()
    {
        maxHp *= statHp;
        damage *= statDamage;
        moveSpeed *= statSpeed;
        jumpPower *= statSpeed;
        attackDelay *= statAttackDelay;
        skillDelay *= statAttackDelay;
    }

    public void StatUp(float hpup,float damageup,float speedup,float delayup)
    {
        statHp += hpup;
        statDamage += damageup;
        statSpeed += speedup;
        statAttackDelay -= delayup;
        RefreshStat();
    }
}
