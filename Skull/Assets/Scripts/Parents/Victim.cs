using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//체력, 피격관련 클래스
public class Victim : MonoBehaviour,Hitable
{
    PlayerUiManager uiManager;
    public float maxHp;

    private float hp;
    public float Hp
    {
        get { return hp; }
        private set { 
            if(value <= 0f)
            {
                hp = 0f;
            } 
            else if(value > maxHp)
            {
                hp = maxHp;
            }
            else
            {
                hp = value;
            }
        }
    }

    void Start()
    {
        hp = maxHp;
        uiManager = FindObjectOfType<PlayerUiManager>();
        uiManager.hpUiSet(Hp, maxHp);
    }

    public virtual float TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            Hp -= damage;
        }
        if(Hp <= 0)
        {
            Die();
        }
        uiManager.hpUiSet(Hp, maxHp);
        return damage;
    }

    public virtual float TakeHeal(float heal)
    {
        if(heal > 0)
        {
            Hp += heal;
        }
        uiManager.hpUiSet(Hp, maxHp);
        return heal;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
