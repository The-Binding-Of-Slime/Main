using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    StatManager statManager;
    [SerializeField] AttackData[] attackDatas;
    float mana;
    float[] coolTime;

    void Start()
    {
        statManager = GetComponent<StatManager>();
        attackDatas = statManager.CharacterData.AttackData;
        coolTime = new float[attackDatas.Length];
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        mana = Mathf.Min(mana + Time.deltaTime, statManager.CharacterData.MaxMana);
        for(int i = 0; i < coolTime.Length; i++)
        {
            coolTime[i] -= Time.deltaTime;
        }
    }

    public void UseAttack(int index)
    {
        if (coolTime[index] <= 0)
        {
            Instantiate(attackDatas[index], transform.position, transform.rotation).GetComponent<HitBox>().damage = attackDatas[index].Damage * statManager.GetStat(PlayerStat.Damage);
            coolTime[index] = attackDatas[index].CoolTime;
        }
    }
}
