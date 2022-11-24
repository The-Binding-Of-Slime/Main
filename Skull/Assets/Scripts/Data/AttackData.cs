using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackData : ScriptableObject
{
    [SerializeField]
    private GameObject attackFrefab;
    public GameObject AttackFrefab
    {
        get { return attackFrefab; }
    }


    [SerializeField]
    private float mana;
    public float Mana
    {
        get { return mana; }
    }


    [SerializeField]
    private float damage;
    public float Damage
    {
        get { return damage; }
    }


    [SerializeField]
    private float frontDelay;
    public float FrontDelay
    {
        get { return frontDelay; }
    }


    [SerializeField]
    private float backDelay;
    public float BackDelay
    {
        get { return backDelay; }
    }


    [SerializeField]
    private float coolTime;
    public float CoolTime
    {
        get { return coolTime; }
    }
}
