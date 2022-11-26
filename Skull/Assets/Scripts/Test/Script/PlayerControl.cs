using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Controller
{
    InputSystem inputSys;
    float attackTimer;
    Attacker attack;

    protected override void Start()
    {
        base.Start();
        inputSys = FindObjectOfType<InputSystem>();
        attack = FindObjectOfType<Attacker>();
    }

    protected override void Update()
    {
        base.Update();
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
                attackTimer = 0.1f;
            }
        }
    }

    protected override void UseAttack(int index)
    {
        attack.UseAttack(index);
    }
}
