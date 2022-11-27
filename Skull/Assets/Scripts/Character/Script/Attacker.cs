using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    StatManager statManager;
    AttackData[] attackDatas;
    float mana;
    float[] coolTime;
    Animator animator;

    void Start()
    {
        statManager = GetComponent<StatManager>();
        animator = GetComponent<Animator>();
        attackDatas = statManager.CharacterData.AttackData;
        coolTime = new float[attackDatas.Length];
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        mana = Mathf.Min(mana + Time.deltaTime, statManager.CharacterData.MaxMana);
        for (int i = 0; i < coolTime.Length; i++)
        {
            coolTime[i] -= Time.deltaTime;
        }
    }

    public void UseAttack(int index)
    {
        if (coolTime[index] <= 0)
        {
            StartCoroutine(SpawnAttackFrefab(index));
            coolTime[index] = attackDatas[index].CoolTime;
            if (animator != null)
            {
                animator.SetTrigger("useAttack");
            }
        }
    }

    IEnumerator SpawnAttackFrefab(int index)
    {
        yield return new WaitForSeconds(attackDatas[index].SpawnDelayTime);
        GameObject prefab = Instantiate(attackDatas[index].AttackFrefab, transform.position, transform.rotation);
        prefab.GetComponent<HitBox>().damage = attackDatas[index].Damage * statManager.GetStat(PlayerStat.Damage);
        prefab.tag = transform.tag;
    }
}
