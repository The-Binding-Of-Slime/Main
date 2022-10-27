using UnityEngine;

[CreateAssetMenu(fileName = "ItemDB", menuName = "Scriptable Object/ItemDB", order = int.MaxValue)]
public class ItemDB : ScriptableObject
{
    [SerializeField]
    public ItemData[] ItemData;
}