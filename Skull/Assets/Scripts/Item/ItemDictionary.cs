using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDictionary", menuName = "Scriptable Object/ItemDictionary", order = int.MaxValue)]
public class ItemDictionary : ScriptableObject
{
    [SerializeField]
    public Item[] Item;
}
