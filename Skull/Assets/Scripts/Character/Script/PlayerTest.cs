using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    PlayerStatManager statManager;
    GoldManager goldManager;

    void Start()
    {
        statManager = GetComponent<PlayerStatManager>();
        goldManager = GetComponent<GoldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            //goldManager.AddMoney(1000);
        }
    }
}
