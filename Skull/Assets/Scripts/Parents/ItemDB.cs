using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemData
{
    public string ItemID;
    public GameObject gameObject;
    public float hp;
    public float damage;
    public float moveSpeed;
    public float mana;
    public float luck;
}
public class ItemDB : MonoBehaviour
{
    [SerializeField]ItemDictionary SCTItemDictionary;
    public Dictionary<string, ItemData> itemDictionary;

    void Start()
    {
        itemDictionary = new Dictionary<string, ItemData>();
        foreach (Item i in SCTItemDictionary.Item)
        {
            itemDictionary.Add(i.ItemData.ItemID, i.ItemData);
            Debug.Log(i.name + "" + i.ItemData);
        }
    }
}