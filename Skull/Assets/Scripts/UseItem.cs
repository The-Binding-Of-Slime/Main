using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public GameObject PlayerControll;
    PlayerControll Player;
    private void Start()
    {
        
    }

    void Shield(float n)
    {
        Player.StatUp(Stat.hp, n);
    }

    void AcidBottle(float n)
    {
        Player.StatUp(Stat.damage, n);
    }

    void RedBull(float n)
    {
        Player.StatUp(Stat.attackDelay, n);
    }
    void OilBottle(float n)
    {
        Player.StatUp(Stat.moveSpeed, n);
    }

    void Pearl(float n)
    {
        Player.StatUp(Stat.luck, n);
    }

    void SuspiciousBottle(float n)
    {
        switch (Random.Range(0, 5))
        {
            case 0:
                Shield(1);
                break;
            case 1:
                AcidBottle(1);
                break;
            case 2:
                RedBull(1);
                break;
            case 3:
                OilBottle(1);
                break;
            case 4:
                Pearl(1);
                break;
            case 5:
                SlimeGell(1);
                break;
            case 6:
                Beer(1);
                break;
        }
    }


    void SlimeGell(float n)
    {

    }

    void Beer(float n)
    {

    }
}
