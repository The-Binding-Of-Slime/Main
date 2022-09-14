using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    Stack<GameObject> uiStack = new Stack<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gotoBeforeUi()
    {
        uiStack.Pop().SetActive(false);
        uiStack.Peek().SetActive(true);
    }

    public void gotoNextUi(GameObject nextUi)
    {
        uiStack.Peek().SetActive(false);
        uiStack.Push(nextUi);
        nextUi.SetActive(true);
    }
}
