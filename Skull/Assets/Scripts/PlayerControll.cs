using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    hp,
    damage,
    moveSpeed,
    attackDelay,
    mana,
    luck
}

public class PlayerControll : Attackable
{
    PlayerInput inputSys;
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer render;

    float originHp;
    float originDamage;
    float originMoveSpeed;
    float originAttackDelay;
    float originMana;
    float originLuck;

    public float moveSpeed;
    public float jumpPower;
    float luck;

    float statDamage = 1;
    float statHp = 1;
    float statSpeed = 1;
    float statAttackDelay = 1;
    float statMana = 1;
    float statLuck = 1;

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
        if (ishit && inputSys.GetJumpDown)
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
        else if (inputSys.Hor < 0f)
        {
            render.flipX = true;
        }

        if (!inputSys.GetHorDown)
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
        Collider2D[] collisions = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 0);
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

    public void initStat(float attack, float hp, float speed, float Delay, float mana, float luck)
    {
        originDamage = attack;
        originHp = hp;
        originMoveSpeed = speed;
        originAttackDelay = Delay;
        originMana = mana;
        originLuck = luck;
        RefreshStat();
    }

    void RefreshStat()
    {
        maxHp = originHp * statHp;
        damage = originDamage * statDamage;
        moveSpeed = originMoveSpeed * statSpeed;
        jumpPower = originMoveSpeed * statSpeed * 3;
        attackDelay = originAttackDelay * statAttackDelay;
        skillDelay = originAttackDelay * statAttackDelay;
        mana = originMana * statMana;
        luck = originLuck * statLuck;
        Debug.Log("HP : " + maxHp + ", Damage : " + damage + ", speed : " + moveSpeed + ", Delay : " + attackDelay);
    }

    public void StatUp(Stat type, float value)
    {
        switch (type)
        {
            case Stat.hp:
                statHp += value;
                break;
            case Stat.damage:
                statDamage += value;
                break;
            case Stat.moveSpeed:
                statSpeed += value;
                break;
            case Stat.attackDelay:
                statAttackDelay -= value;
                break;
            case Stat.mana:
                statMana += value;
                break;
            case Stat.luck:
                statLuck += value;
                break;
        }
        RefreshStat();
    }
}
