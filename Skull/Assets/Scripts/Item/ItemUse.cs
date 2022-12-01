using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemUse : MonoBehaviour
{
    ItemDB itemDB;
    PlayerStatManager manager;
    GoldManager goldManager;

    private void Start()
    {
        itemDB = FindObjectOfType<ItemDB>();
        manager = GetComponent<PlayerStatManager>();
        goldManager = GetComponent<GoldManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShopItem") && FindObjectOfType<InputSystem>().GetInteractionStay)
        {

            ItemData itemData = itemDB.itemDictionary[collision.gameObject.GetComponent<ItemName>().itemName];

            manager.AddStat(PlayerStat.Hp, itemData.hp);
            manager.AddStat(PlayerStat.Damage, itemData.damage);
            manager.AddStat(PlayerStat.MoveSpeed, itemData.moveSpeed);
            manager.AddStat(PlayerStat.AttackSpeed, itemData.mana);
            manager.AddStat(PlayerStat.Luck, itemData.luck);

            goldManager.Buy(itemData.gold);

            collision.gameObject.SetActive(false);
        }
    }
}
