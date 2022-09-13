using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Trigger, Interaction
{
    public bool isAfterDestroy;
    public bool isOnce;
    public bool isSensor;
    bool count = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isSensor && collision.GetComponentInParent<PlayerControll>() != null)
        {
            foreach (Interaction inter in GetComponents<Interaction>())
            {
                inter.interaction();
            }
        }
    }

    public void interaction()
    {
        if(count && !isOnce)
        {
            return;
        }
        count = true;
        input(true);
        output();
        if (isAfterDestroy)
        {
            gameObject.SetActive(false);
        }
    }
}
