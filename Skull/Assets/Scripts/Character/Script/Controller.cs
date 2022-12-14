using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    protected Mover mover;
    protected Attacker attacker;
    protected SpriteRenderer render;
    protected Animator animator;
    float originScaleX;
    bool isRunFrameCount;

    protected virtual void Start()
    {
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
        render = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        originScaleX = transform.localScale.x;
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
        if (mover != null)
        {
            isRunFrameCount = true;
            mover.Move(direction);
            if (direction > 0)
            {
                transform.localScale = new Vector3(1 * originScaleX, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-1 * originScaleX, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    protected virtual void UseAttack(int index)
    {
        if (attacker != null)
        {
            if (attacker.UseAttack(index))
            {
                if (animator != null)
                {
                    animator.SetTrigger("useAttack");
                }
            }
        }
    }

    protected virtual void Jump()
    {
        bool isGround = Physics2D.Raycast(transform.position + Vector3.down * 1.3f, Vector2.down, 0.1f).collider != null;
        if (mover != null && isGround)
        {
            mover.Jump();
        }
    }
}
