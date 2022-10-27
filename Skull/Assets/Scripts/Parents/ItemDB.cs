using UnityEngine;

[CreateAssetMenu(fileName = "ItemDB", menuName = "Scriptable Object/ItemDB", order = int.MaxValue)]
public class ItemDB : ScriptableObject
{
    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }
    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }
    [SerializeField]
    private float attackDelay;
    public float AttackDelay { get { return attackDelay; } }
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
}