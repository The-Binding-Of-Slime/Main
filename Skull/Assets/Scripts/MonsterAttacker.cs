using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAttacker : Attacker
{
    Animator animator;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override bool useAttack()
    {
        if (base.useAttack())
        {
            animator.SetTrigger("SleepSkill");
            return true;
        }
        else
        {
            return false;
        }
    }
}
