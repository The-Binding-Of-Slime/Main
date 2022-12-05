using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    protected Rigidbody2D rigid;
    protected StatManager statManager;
    bool isRunFrameCount;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        statManager = GetComponent<StatManager>();
    }

    protected virtual void Update()
    {
        /*if (animator != null)
        {
            animator.SetBool("isRunning", isRunFrameCount);
            isRunFrameCount = false;
        }*/
    }

    public virtual bool Move(float direction)
    {
        if (!statManager.GetBuff(Buff.Stun))
        {
            if (!statManager.GetBuff(Buff.SpeedUp))
            {
                rigid.velocity = new Vector2(direction * statManager.GetStat(PlayerStat.MoveSpeed), rigid.velocity.y);
            }
            else
            {
                rigid.velocity = new Vector2(direction * statManager.GetStat(PlayerStat.MoveSpeed) * 1.5f, rigid.velocity.y);
            }
            return true;
        }
        else
        {
            return false;
        }
        
        //isRunFrameCount = true;
    }

    public void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 7);
    }
}
