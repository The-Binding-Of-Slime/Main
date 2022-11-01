using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public enum Stat
{
    hp,
    damage,
    moveSpeed,
    attackDelay,
    mana,
    luck
}

public class PlayerStatManger : MonoBehaviour
{
    PlayerControl control;
    Attacker attacker;
    Victim victim;

    //������ ������ ����Ǵ� ����
    float originHp;
    float originDamage;
    float originMoveSpeed = 1;
    float originAttackDelay;
    float originMana;
    float originLuck;

    //���ӳ� ���������� ���ǵ��� ����Ǵ� ���Ȱ��
    float statDamage = 1;
    float statHp = 1;
    float statSpeed = 1;
    float statAttackDelay = 1;
    float statMana = 1;
    float statLuck = 1;

    float luck;

    bool startCount = false;
    void Start()
    {
        if (!startCount)
        {
            return;
        }
        startCount = true;
        control = GetComponent<PlayerControl>();
        attacker = GetComponent<Attacker>();
        victim = GetComponent<Victim>();
        RefreshStat();
    }

    public void InitStat(float attack, float hp, float speed, float Delay, float mana, float luck)
    {
        originDamage = attack;
        originHp = hp;
        originMoveSpeed = speed;
        originAttackDelay = Delay;
        originMana = mana;
        originLuck = luck;
        RefreshStat();
    }

    void RefreshStat()
    {
        Debug.Log(victim);
        victim.maxHp = originHp * statHp;
        attacker.damage = originDamage * statDamage;
        control.SetSpeed(originMoveSpeed * statSpeed, 6);
        attacker.attackDelay = originAttackDelay * statAttackDelay;
        attacker.skillDelay = originAttackDelay * statAttackDelay;
        attacker.mana = originMana * statMana;
        
        luck = originLuck * statLuck;
        //Debug.Log("HP : " + maxHp + ", Damage : " + damage + ", speed : " + moveSpeed + ", Delay : " + attackDelay);
    }

    public void StatUp(Stat type, float value)
    {
        switch (type)
        {
            case Stat.hp:
                statHp += value;
                break;
            case Stat.damage:
                statDamage += value;
                break;
            case Stat.moveSpeed:
                statSpeed += value;
                break;
            case Stat.attackDelay:
                statAttackDelay -= value;
                break;
            case Stat.mana:
                statMana += value;
                break;
            case Stat.luck:
                statLuck += value;
                break;
        }
        RefreshStat();
    }

    
}