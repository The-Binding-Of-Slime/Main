using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    protected Rigidbody rigid;
    protected StatManager statManager;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody>();
        statManager = GetComponent<StatManager>();
    }

    public virtual void Move(float dirction)
    {
        rigid.AddForce(Vector2.right * dirction * statManager.GetStat(PlayerStat.MoveSpeed));
    }
}
