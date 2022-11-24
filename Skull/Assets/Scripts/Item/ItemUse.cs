using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemUse : MonoBehaviour
{
    ItemDB itemDB;
    //PlayerStatManger manager;

    private void Start()
    {
        itemDB = FindObjectOfType<ItemDB>();
        //manager = GetComponent<PlayerStatManger>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShopItem") && FindObjectOfType<PlayerInput>().GetInteractionStay)
        {

            ItemData itemData = itemDB.itemDictionary[collision.gameObject.GetComponent<ItemName>().itemName];

            //manager.StatUp(Stat.hp, itemData.hp);
            //manager.StatUp(Stat.damage, itemData.damage);
            //manager.StatUp(Stat.moveSpeed, itemData.moveSpeed);
            //manager.StatUp(Stat.mana, itemData.mana);
            //manager.StatUp(Stat.luck, itemData.luck);

            collision.gameObject.SetActive(false);
        }
    }
}
