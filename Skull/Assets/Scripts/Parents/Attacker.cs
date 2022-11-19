using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour, Attack
{
    [SerializeField]protected float attackDelay;
    public float attackDamage;
    float attackTimer;
    public float AttackTimer
    {
        get { return attackTimer; }
        private set { attackTimer = value; }
    }

    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        attackTimer -= Time.deltaTime;
    }

    public virtual void UseAttack()
    {
        if (attackTimer > 0f)
        {
            return;
        }
        attackTimer = attackDelay;
    }
}
