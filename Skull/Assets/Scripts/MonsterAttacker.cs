using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAttacker : RangeAttacker
{
    Animator animator;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void UseAttack()
    {
        base.UseAttack();
        animator.SetTrigger("SleepSkill");
    }
}
