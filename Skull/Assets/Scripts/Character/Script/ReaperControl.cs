using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ReaperControl : TrackerControl
{
    bool isHide;

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
            if (!isHide)
            {
                if(Distance < attackRange)
                {
                    UseAttack(0);
                }
                else
                {
                    UseAttack(1);
                }
            }
            else
            {
                if(Distance < attackRange)
                {
                    BackTracking();
                }
                else
                {
                    
                }
            }
        }
    }

    protected override void UseAttack(int index)
    {
        if (isHide)
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
