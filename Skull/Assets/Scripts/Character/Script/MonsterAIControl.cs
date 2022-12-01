using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIControl : TrackerControl
{

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (IsFind && Distance > attackRange)
        {
            Tracking();
        }
        if (IsFind && Distance <= attackRange)
        {
            UseAttack(0);
        }
    }
}
