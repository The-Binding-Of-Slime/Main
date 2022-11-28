using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttacker : Attacker
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void UseAttack()
    {
        Collider2D[] hitedColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale,0f);
        foreach(Collider2D col in hitedColliders)
        {
            Victim victim = col.GetComponent<Victim>();
            if (victim != null)
            {
                victim.TakeDamage(attackDamage);
            }
        }
    }
}
