using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ReaperControl : TrackerControl
{
    bool IsHide
    {
        get
        {
            return animator.GetBool("isClocking");
        }
        set
        {
            animator.SetBool("isClocking", value);
            attacker.UseAttack(2);
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (IsFind)
        {
            if (!IsHide)
            {
                if(Distance < attackRange)
                {
                    UseAttack(0);
                }
                else if(Distance < 5)
                {
                    UseAttack(1);
                }
                else
                {
                    IsHide = true;
                }
            }
            else
            {
                if(Distance < attackRange)
                {
                    IsHide = false;
                }
                else
                {
                    Tracking();
                }
            }
        }
    }

    protected override void UseAttack(int index)
    {
        if (IsHide)
        {
            return;
        }
        if (attacker != null)
        {
            if (attacker.UseAttack(index))
            {
                if (animator != null)
                {
                    if (index == 0)
                    {
                        animator.SetTrigger("useAttack");
                    }else if(index == 1)
                    {
                        animator.SetTrigger("useLightning");
                    }
                }
            }
        }
    }
}
