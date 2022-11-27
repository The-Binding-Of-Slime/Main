using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    protected Rigidbody2D rigid;
    protected StatManager statManager;
    Animator animator;
    bool isRunFrameCount;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        statManager = GetComponent<StatManager>();
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

    public virtual void Move(float direction)
    {
        rigid.velocity = new Vector2(direction * statManager.GetStat(PlayerStat.MoveSpeed),rigid.velocity.y);
        isRunFrameCount = true;
    }

    public void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 7);
    }
}
