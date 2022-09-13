using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Trigger, Interaction
{
    public Transform targetPos;
    public void interaction()
    {
        FindObjectOfType<PlayerControll>().transform.position = targetPos.position;
    }
}
