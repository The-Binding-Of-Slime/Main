using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : StatManager
{
    float[] playerStat;

    protected override void Start()
    {
        for (int i = 0; i < System.Enum.GetValues(typeof(PlayerStat)).Length; i++)
        {
            playerStat[i] = 1f;
        }
    }

    public void AddStat(PlayerStat addedStat,float value)
    {
        playerStat[(int)addedStat] += value;
    }

    public float GetStat(PlayerStat stat)
    {
        return playerStat[(int)stat];
    }
}
