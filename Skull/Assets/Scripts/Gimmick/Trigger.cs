using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject[] target;
    public bool defaultActive;
    public bool reverse;
    public bool IsActive { get; protected set; }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {
        
    }

    protected virtual void OnEnable()
    {
        input(defaultActive);
    }

    public virtual void input(bool val)
    {
        IsActive = val != reverse;
    }

    public virtual void output()
    {
        foreach(GameObject go in target)
        {
            go.GetComponent<Trigger>().input(IsActive);
        }
    }
}
