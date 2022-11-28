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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UiSet(float value,float maxValue)
    {
        if (slider != null)
        {
            slider.value = value / maxValue;
        }
        if (text != null)
        {
            text.text = ((int)value).ToString() + " / " + ((int)maxValue).ToString() + " " + lastText;
        }
    }

    public void UiSet(float value)
    {
        if(text != null)
        {
            text.text = ((int)value).ToString() + " " + lastText;
        }
    }
}
