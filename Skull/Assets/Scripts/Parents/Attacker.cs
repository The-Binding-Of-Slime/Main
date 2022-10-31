using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//공격, 스킬 사용 클래스
//구현은 공격 오브젝트 프리팹에서
public class Attacker : MonoBehaviour
{
    public GameObject attack;
    public GameObject skill;
    public float attackDelay;
    public float skillDelay;
    public float damage = 1;
    public float attackDamage;
    public float skillDamage;
    public float skillMana;
    public float mana = 0;

    float attackTimer;
    float skillTimer;

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
        if (attackTimer <= 0f)
        {
            attackTimer = attackDelay;
            GameObject attackObject = Instantiate(attack, transform.position, transform.rotation);
            attackObject.GetComponent<DamageSkill>().set(damage * attackDamage,false);
        }
    }

    protected void useSkill()
    {
        if(skillMana > mana)
        {
            return;
        }
        else
        {
            mana -= skillMana;
        }
        if (skillTimer <= 0f)
        {
            skillTimer = skillDelay;
            GameObject skillObject = Instantiate(skill, transform.position, transform.rotation);
            skillObject.GetComponent<DamageSkill>().set(damage * attackDamage, false);
        }
    }
}
