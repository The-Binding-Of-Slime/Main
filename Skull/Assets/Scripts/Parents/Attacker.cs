using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//공격, 스킬 사용 클래스
//구현은 공격 오브젝트 프리팹에서
public class Attacker : MonoBehaviour
{
    [SerializeField] GameObject attack;
    [SerializeField] GameObject skill;
    [SerializeField]float attackDelay;
    [SerializeField]float skillDelay;
    public float damage = 1;
    public float attackDamage;
    public float skillDamage;
    public float skillMana;
    public float mana = 0;

    float attackTimer;
    public float AttackTimer
    {
        get { return attackTimer; }
        private set { attackTimer = value; }
    }
    float skillTimer;
    public float SkillTimer
    {
        get { return skillTimer; }
        private set { skillTimer = value; }
    }

    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        skillTimer -= Time.deltaTime;
    }

    public virtual bool useAttack()
    {
        if (attackTimer > 0f)
        {
            return false;
        }
        attackTimer = attackDelay;
        if (attack != null)
        {
            GameObject attackObject = Instantiate(attack, transform.position, transform.rotation);
            attackObject.GetComponent<DamageSkill>().set(damage * attackDamage, false);
        }
        return true;
    }

    public virtual void useSkill()
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
