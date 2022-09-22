using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Attackable : Hitable
{
    public GameObject attack;
    public GameObject skill;
    public float attackDelay;
    public float skillDelay;
    protected float damage = 1;
    public float attackDamage;
    public float skillDamage;

    public float attackTimer {
        get { return attackTimer; }
        set
        {
            if(value > 0f)
            {
                attackTimer = value;
            }
            else
            {
                attackTimer = 0f;
            }
        }
    }
    public float skillTimer
    {
        get { return skillTimer; }
        set
        {
            if (value > 0f)
            {
                skillTimer = value;
            }
            else
            {
                skillTimer = 0f;
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        skillTimer -= Time.deltaTime;
    }

    protected void useAttack()
    {
        if (attackTimer == 0f)
        {
            attackTimer = attackDelay;
            GameObject attackObject = Instantiate(attack, transform.position, transform.rotation);
            attackObject.GetComponent<DamageSkill>().set(damage * attackDamage,false);
        }
    }

    protected void useSkill()
    {
        if (skillTimer == 0f)
        {
            skillTimer = skillDelay;
            GameObject skillObject = Instantiate(skill, transform.position, transform.rotation);
            skillObject.GetComponent<DamageSkill>().set(damage * attackDamage, false);
        }
    }
}
