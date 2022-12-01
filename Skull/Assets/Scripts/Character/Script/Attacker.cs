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
    public float Mana { get; private set; }
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
        Mana = Mathf.Min(Mana + Time.deltaTime, statManager.GetStat(PlayerStat.Mana));
        for (int i = 0; i < coolTime.Length; i++)
        {
            coolTime[i] -= Time.deltaTime;
        }
    }

    public bool UseAttack(int index)
    {
        if (coolTime[index] <= 0)
        {
            StartCoroutine(SpawnAttackFrefab(index));
            coolTime[index] = attackDatas[index].CoolTime;
            return true;
        }
        else
        {
            return false;
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
