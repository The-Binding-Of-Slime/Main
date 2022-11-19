using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//����, ��ų ��� Ŭ����
//������ ���� ������Ʈ �����տ���
public class RangeAttacker : Attacker
{
    [SerializeField] GameObject attack;
    [SerializeField] GameObject skill;
    [SerializeField]float skillDelay;
    public float damage = 1;
    public float skillDamage;
    public float skillMana;
    public float mana = 0;

    float skillTimer;
    public float SkillTimer
    {
        get { return skillTimer; }
        private set { skillTimer = value; }
    }

    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        skillTimer -= Time.deltaTime;
    }

    public override void UseAttack()
    {
        base.UseAttack();
        if (attack != null)
        {
            GameObject attackObject = Instantiate(attack, transform.position, transform.rotation);
            attackObject.GetComponent<DamageSkill>().set(damage * attackDamage, false);
        }
    }

    public virtual void UseSkill()
    {
        if(skillMana > mana || skillTimer > 0)
        {
            return;
        }
        mana -= skillMana;
        skillTimer = skillDelay;
        GameObject skillObject = Instantiate(skill, transform.position, transform.rotation);
        skillObject.GetComponent<DamageSkill>().set(damage * skillDamage, false);
    }

    public void SetStat(float damage,float attackDelay,float skillDelay)
    {
        this.damage = damage;
        this.attackDelay = attackDelay;
        this.skillDelay = skillDelay;
    }
}
