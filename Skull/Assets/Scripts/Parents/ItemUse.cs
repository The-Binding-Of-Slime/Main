using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemUse : MonoBehaviour
{
    ItemDB itemDB;
    PlayerStatManger manager;

    private void Start()
    {
        itemDB = FindObjectOfType<ItemDB>();
        manager = GetComponent<PlayerStatManger>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ShopItem") && FindObjectOfType<PlayerInput>().GetInteractionStay){

            ItemData itemData = itemDB.itemDictionary[collision.gameObject.GetComponent<ItemName>().itemName];

            Debug.Log(itemData.hp);
            Debug.Log(itemData.damage);
            Debug.Log(itemData.moveSpeed);
            Debug.Log(itemData.attackDelay);
            Debug.Log(itemData.luck);

            manager.StatUp(Stat.hp,itemData.hp);
            manager.StatUp(Stat.damage,itemData.damage);
            manager.StatUp(Stat.moveSpeed, itemData.moveSpeed);
            manager.StatUp(Stat.attackDelay, itemData.attackDelay);
            manager.StatUp(Stat.luck, itemData.luck);

            Debug.Log(itemData.hp);
            Debug.Log(itemData.damage);
            Debug.Log(itemData.moveSpeed);
            Debug.Log(itemData.attackDelay);
            Debug.Log(itemData.luck);
        }
    }
}
