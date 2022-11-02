using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemData
{
    public string ItemID;
    public int hp;
    public int damage;
    public float moveSpeed;
    public float attackDelay;
    public float luck;
}
public class ItemGuide : MonoBehaviour
{
    Dictionary<string, ItemData> ItemDictionary;

    void Start()
    {
        ItemDictionary = new Dictionary<string, ItemData>();
    }
}