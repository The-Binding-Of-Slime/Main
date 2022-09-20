using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class PlayerControll : Attackable
{
    PlayerInput inputSys;
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer render;
    public float moveSpeed;
    public float jumpPower;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        inputSys = FindObjectOfType<PlayerInput>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position + Vector3.down * 0.9f, Vector2.down, 0.4f);
        bool isGroundHit = hit.collider != null && !hit.collider.isTrigger;
        if(isGroundHit && inputSys.GetJumpDown)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
            animator.SetBool("isJump", true);
        }

        if (isGroundHit && !animator.GetBool("isGround"))
        {
            animator.SetBool("isJump", false);
        }

        if (isGroundHit)
        {
            animator.SetBool("isGround", true);
        }
        else
        {
            animator.SetBool("isGround", false);
        }

        if(!inputSys.GetHorDown)
        {
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
        }

        if (inputSys.Hor > 0f)
        {
            render.flipX = false;
        }
        else if (inputSys.Hor < 0f)
        {
            render.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        if (inputSys.GetHorDown && Mathf.Abs(rigid.velocity.x) < moveSpeed)
        {
            rigid.AddForce(new Vector2(inputSys.Hor, 0f) * moveSpeed * 30);
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
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
    }
}
