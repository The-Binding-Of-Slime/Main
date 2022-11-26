using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    protected Rigidbody2D rigid;
    protected StatManager statManager;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        statManager = GetComponent<StatManager>();
    }

    public virtual void Move(float direction)
    {
        rigid.velocity = Vector2.right * direction * statManager.GetStat(PlayerStat.MoveSpeed);
    }

    public void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 7);
    }
}
