using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    public float maxHp;
    public float hp
    {
        get { return maxHp; }
        private set { 
            if(value <= 0)
            {
                hp = 0;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void takeDamage(float damage)
    {
        if (damage > 0)
        {
            hp -= damage;
        }
        if(hp <= 0)
        {
            Die();
        }
    }

    public virtual void takeHeal(float heal)
    {
        if(heal > 0)
        {
            hp += heal;
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
