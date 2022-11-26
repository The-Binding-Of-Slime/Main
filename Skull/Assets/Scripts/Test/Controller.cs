using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Mover mover;
    StatManager statManager;
    Attacker attacker;

    protected virtual void Start()
    {
        mover = GetComponent<Mover>();
        statManager = GetComponent<StatManager>();
        attacker = GetComponent<Attacker>();
    }

    protected virtual void Move(float direction)
    {
        mover.Move(direction);
    }

    protected virtual void UseAttack(int index)
    {
        attacker.UseAttack(index);
    }

    protected virtual void Jump()
    {
        mover.Jump();
    }
}
