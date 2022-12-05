using Newtonsoft.Json.Linq;
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
    [SerializeField]string lastText;
    float maxValue;
    float targetValue;
    float showValue;
    int mode; // 0 : ����, 1 : MaxValue ����, 2 : MaxValue ����

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode != 0)
        {
            if(Mathf.Abs(showValue - targetValue) > 1)
            {
                showValue = Mathf.Lerp(showValue, targetValue, Time.deltaTime * 10);
            }
            else
            {
                showValue = targetValue;
            }
            if(mode == 1)
            {
                if (text != null)
                {
                    text.text = ((int)showValue).ToString() + " " + lastText;
                }
            }else if(mode == 2)
            {
                if (slider != null)
                {
                    slider.value = showValue / maxValue;
                }
                if (text != null)
                {
                    text.text = ((int)showValue).ToString() + " / " + ((int)maxValue).ToString() + " " + lastText;
                }
            }
        }
    }


    public void UiSet(float value,float maxValue)
    {
        this.maxValue = maxValue;
        targetValue = value;
        manageMoad(2);
    }

    public void UiSet(float value)
    {
        targetValue = value;
        manageMoad(1);
    }

    void manageMoad(int mode)
    {
        if(this.mode == 0)
        {
            showValue = targetValue;
        }
        this.mode = mode;
    }
}
