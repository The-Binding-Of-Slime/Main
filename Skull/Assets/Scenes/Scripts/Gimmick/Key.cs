using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Key : Trigger, Interaction
{
    [Header("-사용시 사라짐")]
    public bool isAfterDestroy;
    [Header("-사용시 비활성화됨")]
    public bool isOnce;
    [Header("-플레이어에게 닿으면 사용됨")]
    public bool isSensor;
    bool count = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isSensor && collision.GetComponentInParent<PlayerControl>() != null)
        {
            foreach (Interaction inter in GetComponents<Interaction>())
            {
                inter.Interaction();
            }
        }
    }

    public void Interaction()
    {
        if(count && !isOnce)
        {
            return;
        }
        count = true;
        Input(true);
        output();
        if (isAfterDestroy)
        {
            gameObject.SetActive(false);
        }
    }
}
