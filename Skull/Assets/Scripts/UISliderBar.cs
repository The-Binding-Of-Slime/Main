using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����̴� ������
//�����̴��� �־ ��
public class UISliderBar : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public string lastText;
    float maxValue;
    float value;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UiSet(float value,float maxValue)
    {
        this.value = value;
        this.maxValue = maxValue;
        if (slider != null)
        {
            slider.value = value / maxValue;
            slider.maxValue = maxValue;
        }
        if (text != null)
        {
            text.text = value.ToString() + " / " + maxValue.ToString() + " " + lastText;
        }
    }

    public void UiSet(float value)
    {
        this.value = value;
        if(text != null)
        {
            text.text = value.ToString() + " " + lastText;
        }
    }
}