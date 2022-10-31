using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Trigger, Interaction
{
    public Transform targetPos;
    public void Interaction()
    {
        FindObjectOfType<PlayerControl>().transform.position = targetPos.position;
    }
}
