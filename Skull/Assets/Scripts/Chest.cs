using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, Interaction
{
    public Sprite open;
    bool isOpen = false;
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void interaction()
    {
        if (!isOpen)
        {
            isOpen = true;
            GetComponent<SpriteRenderer>().sprite = open;
        }
    }
}
