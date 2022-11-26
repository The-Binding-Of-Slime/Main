using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Mover mover;
    Attacker attacker;
    SpriteRenderer render;
    Animator animator;
    bool isRunFrameCount;

    protected virtual void Start()
    {
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        if (animator != null)
        {
            animator.SetBool("isRunning", isRunFrameCount);
            isRunFrameCount = false;
        }
    }

    protected virtual void Move(float direction)
    {
        isRunFrameCount = true;
        mover.Move(direction);
        if(direction > 0)
        {
            render.flipX = false;
        }
        else
        {
            render.flipX = true;
        }
    }

    protected virtual void UseAttack(int index)
    {
        if (animator != null)
        {
            animator.SetTrigger("useAttack");
        }
        attacker.UseAttack(index);
    }

    protected virtual void Jump()
    {
        mover.Jump();
    }
}
