using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Controller
{
    InputSystem inputSys;
    float attackTimer;

    protected override void Start()
    {
        inputSys = FindObjectOfType<InputSystem>();
    }

    protected void Update()
    {
        attackTimer -= Time.deltaTime;
        if(inputSys != null)
        {
            if (inputSys.GetHorDown)
            {
                Move(inputSys.Hor);
            }
            if (inputSys.GetJumpDown)
            {
                Jump();
            }
            if(attackTimer <= 0)
            {
                UseAttack(0);
                attackTimer = 0.25f;
            }
        }
    }
}
