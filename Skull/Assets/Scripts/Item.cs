using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public PlayerControll PlayerControll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInput inputSys = PlayerInput.Instance;

        bool CanUseItem = false;

        if (collision.gameObject.tag == "Player")
        {
            bool HpItem = collision.gameObject.name.Contains("Slime");
            bool DamageItem = collision.gameObject.name.Contains("Acid");
            bool MoveSpeedItem = collision.gameObject.name.Contains("Oil");
            bool AttackDelayItem = collision.gameObject.name.Contains("RedBull");
            bool LuckItem = collision.gameObject.name.Contains("Pearl");

            if (CanUseItem)
            {
                if (HpItem)
                {
                    PlayerControll.StatUp(Stat.hp, 0);
                    
                }
                else if (DamageItem)
                {
                    PlayerControll.StatUp(Stat.damage, 0);
                }
                else if (MoveSpeedItem)
                {
                    PlayerControll.StatUp(Stat.moveSpeed, 0);
                }
                else if (AttackDelayItem)
                {
                    PlayerControll.StatUp(Stat.attackDelay, 0);
                }
                else if (LuckItem)
                {
                    PlayerControll.StatUp(Stat.luck, 0);
                }

            }

            if (inputSys.GetInteractionDown)
            {
                //°ñµå Ãß°¡ÇØ!
                if(CanUseItem == false)
                {
                    CanUseItem = true;
                    //ÇÃ·¹ÀÌ¾î °ñµå ±ï´Â ÄÚµå
                }
            }
        }
    }
}