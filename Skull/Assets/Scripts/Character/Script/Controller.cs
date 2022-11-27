using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Mover mover;
    Attacker attacker;
    SpriteRenderer render;

    protected virtual void Start()
    {
        mover = GetComponent<Mover>();
        attacker = GetComponent<Attacker>();
        render = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {

    }
    
    protected virtual void Move(float direction)
    {
        if (mover != null)
        {
            mover.Move(direction);
            if (direction > 0)
            {
                render.flipX = false;
            }
            else
            {
                render.flipX = true;
            }
        }
    }

    protected virtual void UseAttack(int index)
    {
        if (attacker != null)
        {
            attacker.UseAttack(index);
        }
    }

    protected virtual void Jump()
    {
        if (mover != null)
        {
            mover.Jump();
        }
    }
}
