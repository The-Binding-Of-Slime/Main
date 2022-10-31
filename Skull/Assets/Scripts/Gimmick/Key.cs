using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Key : Trigger, Interaction
{
    [Header("-���� �����")]
    public bool isAfterDestroy;
    [Header("-���� ��Ȱ��ȭ��")]
    public bool isOnce;
    [Header("-�÷��̾�� ������ ����")]
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
