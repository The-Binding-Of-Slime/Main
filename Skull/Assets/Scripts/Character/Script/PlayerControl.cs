using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Controller
{
    InputSystem inputSys;
    float attackTimer;
    Attacker attack;
    StatManager statManager;

    protected override void Start()
    {
        base.Start();
        inputSys = FindObjectOfType<InputSystem>();
        attack = GetComponent<Attacker>();
        statManager = GetComponent<StatManager>();
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
            animator.SetBool("isSpin", inputSys.GetSkill1Stay);
            if (inputSys.GetSkill1Stay)
            {
                statManager.AddBuff(Buff.SpeedUp, 0.25f);
                statManager.AddBuff(Buff.DamageUp, 0.25f);
            }
            if (attackTimer <= 0)
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
