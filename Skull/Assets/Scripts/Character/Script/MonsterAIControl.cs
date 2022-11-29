using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIControl : TrackerControl
{

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Find();

        if (IsFind && Distance > moveMinRange)
        {
            Tracking();
        }
        if (IsFind && Distance <= moveMinRange)
        {
            UseAttack(0);
        }
    }
}
