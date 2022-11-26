using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Victim : MonoBehaviour
{
    StatManager statManager;

    private float hp;
    public float HP {
        get { return hp; }
        private set {
            hp = Mathf.Clamp(0,value,statManager.GetStat(PlayerStat.Hp));
        }
    }

    private void Start()
    {
        statManager = GetComponent<StatManager>();
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void TakeHeal(float heal)
    {
        hp += heal;
    }
}
