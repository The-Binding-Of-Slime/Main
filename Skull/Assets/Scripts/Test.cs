using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    UiManager ui;
    public float value;
    public float maxValue;
    void Start()
    {
        ui = GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ui.expUiSet(value, maxValue);
    }
}
