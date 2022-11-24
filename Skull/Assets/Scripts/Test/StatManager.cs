using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    protected CharacterData characterData;
    float[] buffList;

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        for(int i = 0; i < System.Enum.GetValues(typeof(Buff)).Length; i++)
        {
            buffList[i] -= Time.deltaTime;
        }
    }

    public void AddBuff(Buff addedBuff, float time)
    {
        if (buffList[(int)addedBuff] < time && time > 0)
        {
            buffList[(int)addedBuff] = time;
        }
    }

    public void ClearBuff(Buff buff)
    {
        buffList[(int)buff] = 0;
    }

    public bool GetBuff(Buff buff)
    {
        return buffList[(int)buff] > 0;
    }
}
