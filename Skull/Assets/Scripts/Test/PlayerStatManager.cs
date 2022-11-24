using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : StatManager
{
    float[] playerStat;
    SavedStatManager savedStatManager;

    protected override void Start()
    {
        base.Start();
        savedStatManager = GetComponent<SavedStatManager>();
        for (int i = 0; i < System.Enum.GetValues(typeof(PlayerStat)).Length; i++)
        {
            playerStat[i] = 1f;
        }
    }

    public void AddStat(PlayerStat addedStat,float value)
    {
        playerStat[(int)addedStat] += value;
    }

    public override float GetStat(PlayerStat stat)
    {
        float value = 1;
        switch (stat)
        {
            case PlayerStat.Hp:
                value = CharacterData.MaxHp;
                break;
            case PlayerStat.Damage:
                value = CharacterData.AttackData.Damage;
                break;
            case PlayerStat.MoveSpeed:
                value = CharacterData.MoveSpeed;
                break;
            case PlayerStat.AttackSpeed:
                value = CharacterData.AttackData.CoolTime;
                break;
            case PlayerStat.Luck:
                value = 1;
                break;
        }
        return (value + savedStatManager.GetStat(stat)) * playerStat[(int)stat];
    }
}
