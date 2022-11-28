using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//슬라이더 관리용 클래스
//캔버스에 넣어서 사용
public class UiManager : MonoBehaviour
{
    public UISliderBar hpSlider;
    public UISliderBar mpSlider;
    public UISliderBar goldSlider;
    public UISliderBar intSlider;
    public UISliderBar expSlider;

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
