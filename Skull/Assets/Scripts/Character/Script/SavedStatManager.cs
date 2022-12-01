using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedStatManager : MonoBehaviour
{
    private void Start()
    {
        //ClearStat();
    }

    private void ClearStat()
    {
        PlayerPrefs.SetFloat("PlayerHp", 0);
        PlayerPrefs.SetFloat("PlayerDamage", 0);
        PlayerPrefs.SetFloat("PlayerMoveSpeed", 0);
        PlayerPrefs.SetFloat("PlayerAttackSpeed", 0);
        PlayerPrefs.SetFloat("PlayerLuck", 0);
        PlayerPrefs.SetFloat("PlayerMana", 0);
    }

    public void AddStat(PlayerStat stat, float value)
    {
        switch (stat)
        {
            case PlayerStat.Hp:
                PlayerPrefs.SetFloat("PlayerHp", PlayerPrefs.GetFloat("PlayerHp") + value);
                break;
            case PlayerStat.Damage:
                PlayerPrefs.SetFloat("PlayerDamage", PlayerPrefs.GetFloat("PlayerDamage") + value);
                break;
            case PlayerStat.MoveSpeed:
                PlayerPrefs.SetFloat("PlayerMoveSpeed", PlayerPrefs.GetFloat("PlayerMoveSpeed") + value);
                break;
            case PlayerStat.AttackSpeed:
                PlayerPrefs.SetFloat("PlayerAttackSpeed", PlayerPrefs.GetFloat("PlayerAttackSpeed") + value);
                break;
            case PlayerStat.Luck:
                PlayerPrefs.SetFloat("PlayerLuck", PlayerPrefs.GetFloat("PlayerLuck") + value);
                break;
            case PlayerStat.Mana:
                PlayerPrefs.SetFloat("PlayerMana", PlayerPrefs.GetFloat("PlayerMana") + value);
                break;
        }
    }

    public float GetStat(PlayerStat stat)
    {
        switch (stat)
        {
            case PlayerStat.Hp:
                return PlayerPrefs.GetFloat("PlayerHp");
            case PlayerStat.Damage:
                return PlayerPrefs.GetFloat("PlayerDamage");
            case PlayerStat.AttackSpeed:
                return PlayerPrefs.GetFloat("PlayerAttackSpeed");
            case PlayerStat.MoveSpeed:
                return PlayerPrefs.GetFloat("PlayerMoveSpeed");
            case PlayerStat.Luck:
                return PlayerPrefs.GetFloat("PlayerLuck");
            case PlayerStat.Mana:
                return PlayerPrefs.GetFloat("PlayerMana");
            default:
                return -1f;
        }
    }
}
