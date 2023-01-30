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
            if (inputSys.GetSkill2Down)
            {
                animator.SetTrigger("useSleep");
                statManager.AddBuff(Buff.Stun, 0.25f);
                statManager.AddBuff(Buff.Immune, 0.25f);
                statManager.AddBuff(Buff.Defence, 5);
            }
            if (attackTimer <= 0)
            {
                UseAttack(0);
                attackTimer = statManager.CharacterData.AttackData[0].CoolTime;
            }

            if (inputSys.GetInteractionDown)
            {
                InteractionCheck();
            }
        }
    }

    protected override void UseAttack(int index)
    {
        attack.UseAttack(index);
    }

    void InteractionCheck()
    {
        Collider2D[] collisions = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 0);
        foreach (Collider2D collision in collisions)
        {
            if (collision.GetComponentInParent<Interaction>() != null)
            {
                Transform go = collision.transform;
                while (go.GetComponentInParent<Interaction>() != null && go.GetComponent<Interaction>() == null)
                {
                    go = go.parent;
                }
                Interaction[] inters = go.GetComponents<Interaction>();
                foreach (Interaction inter in inters)
                {
                    inter.Interaction();
                }
                //gameObject.SetActive(false);
            }
        }
    }
}
