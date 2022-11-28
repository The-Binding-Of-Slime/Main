using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDataSender : MonoBehaviour
{
    UiManager ui;
    StatManager statManager;
    Victim victim;
    Attacker attacker;

    void Start()
    {
        ui = FindObjectOfType<UiManager>();
        statManager = GetComponent<StatManager>();
        victim = GetComponent<Victim>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {
        ui.hpUiSet(victim.HP, statManager.GetStat(PlayerStat.Hp));
        ui.mpUiSet(attacker.Mana, statManager.CharacterData.MaxMana);
    }
}
