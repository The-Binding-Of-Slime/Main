using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkill : MonoBehaviour 
{
    public float skillDamage;
    public bool isDotDamage;
    GameObject[] hitList;
    float dotTimer
    {
        get { return dotTimer; }
        set
        {
            if (value > 0f)
            {
                dotTimer = value;
            }
            else
            {
                dotTimer = 0f;
            }
        }
    }

    private void Update()
    {
        dotTimer-=Time.deltaTime;
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (!isDotDamage)
        {
            bool isIn=false;
            foreach(GameObject go in hitList)
            {
                if(go == collision.GetComponentInParent<Hitable>().gameObject)
                {
                    isIn=true;
                }
            }
            if (isIn)
            {
                collision.GetComponentInParent<Hitable>().takeDamage(skillDamage);
            }
        }
        else
        {
            if(dotTimer == 0f)
            {
                collision.GetComponentInParent<Hitable>().takeDamage(skillDamage / 4f);
                dotTimer = 0.25f;
            }
        }
    }

    public void set(float damageValue , bool dotValue)
    {
        skillDamage = damageValue;
        isDotDamage = dotValue;
    }
}
