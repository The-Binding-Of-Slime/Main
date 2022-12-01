using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public int Gold { private set; get; }

    public void AddMoney(int gold)
    {
        if(gold > 0) {
            Gold += gold;
            Debug.Log(Gold);
        }
    }

    public bool Buy(int price)
    {
        if(Gold >= price)
        {
            Gold -= price;
            return true;
        }
        else
        {
            return false;
        }
    }
}
