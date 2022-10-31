using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//체력, 피격관련 클래스
public class Victim : MonoBehaviour
{
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
    }

    public virtual void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            Hp -= damage;
        }
        if(Hp <= 0)
        {
            Die();
        }
    }

    public virtual void TakeHeal(float heal)
    {
        if(heal > 0)
        {
            Hp += heal;
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
