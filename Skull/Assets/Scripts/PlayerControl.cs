using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이동, 애니메이션 구현 클래스
public class PlayerControl : Mover
{
    PlayerInput inputSys;
    Animator animator;
    SpriteRenderer render;

    private float spinGauge;

    float SpinGauge
    {
        get { return spinGauge; }
        set {
            if (value < 0)
            {
                spinGauge = 0;
            }
            else
            {
                spinGauge = value;
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        inputSys = FindObjectOfType<PlayerInput>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputSys.Hor > 0f)
        {
            render.flipX = false;
        }
        else if (inputSys.Hor < 0f)
        {
            render.flipX = true;
        }

        animator.SetBool("isRunning", inputSys.GetHorDown);

        if (inputSys.GetInteractionDown)
        {
            InteractionCheck();
        }
        if (inputSys.GetSkill2Down)
        {
            animator.SetTrigger("SleepSkill");
        }
        animator.SetBool("SpinSkill", (inputSys.GetSkill1Stay));


        if (inputSys.GetSkill1Stay)
        {
            SpinGauge+= Time.deltaTime;
        }
        else
        {
            SpinGauge-= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (inputSys.GetHorDown && Mathf.Abs(Rigid.velocity.x) < moveSpeed)
        {
            //rigid.AddForce(30 * moveSpeed * new Vector2(inputSys.Hor, 0f));
            Move(inputSys.Hor);
        }


        bool isGround = CheckIsGround();
        if (isGround && inputSys.GetJumpDown)
        {
            Jump();
            animator.SetTrigger("Jump");
        }

        animator.SetBool("isGround", isGround);
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

    void InteractionCheck()
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
                    inter.Interaction();
                }
                //gameObject.SetActive(false);
            }
        }
    }

    

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            string itemName = collision.gameObject.name;
            switch (itemName)
            {
                case "Slime Gel":
                    break;
                case "Shield":
                    break;
                case "Suspicious Bottle":
                    break;
                case "Pearl":
                    break;
                case "Iron":
                    break;
                case "Oil Bottle":
                    break;
                case "Acid Bottle":
                    break;
                case "Red Bull":
                    break;
                case "Beer":
                    break;
            }
            Destroy(collision.gameObject);
        }
    }*/
}
