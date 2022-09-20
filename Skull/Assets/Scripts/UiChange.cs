using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiChange : MonoBehaviour
{
    public GameObject nextUi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gotoNext()
    {
        FindObjectOfType<UiManager>().gotoNextUi(nextUi);
    }

    public void gotoBeforeUi()
    {
        FindObjectOfType<UiManager>().gotoBeforeUi();
    }
}
