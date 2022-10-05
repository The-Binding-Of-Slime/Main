using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerUiManager : MonoBehaviour
{
    public PlayerUiTerminal hpSlider;
    public PlayerUiTerminal mpSlider;
    public PlayerUiTerminal goldSlider;
    public PlayerUiTerminal intSlider;
    public PlayerUiTerminal expSlider;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hpUiSet(float hp, float maxHp)
    {
        hpSlider.UiSet(hp, maxHp);
    }

    public void mpUiSet(float mp, float maxMp)
    {
        mpSlider.UiSet(mp, maxMp);
    }

    public void goldUiSet(float gold)
    {
        goldSlider.UiSet(gold);
    }

    public void intUiSet(float intValue)
    {
        intSlider.UiSet(intValue);
    }

    public void expUiSet(float exp,float maxExp)
    {
        expSlider.UiSet(exp, maxExp);
    }
}
