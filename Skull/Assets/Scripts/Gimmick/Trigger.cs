using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ȣ�ۿ� ���� ������Ʈ ������

[ExecuteInEditMode]
public class Trigger : MonoBehaviour
{
    [Header("-��ȣ���� Ÿ��")]
    public GameObject[] target;
    [Header("-�⺻ �Է�")]
    public bool defaultActive;
    [Header("-�Է¹��� ����")]
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
        Input(defaultActive);
    }

    //�⺻ �Է�
    //�ٸ� Trigger�� output �̳� �÷��̾ ���� ȣ���
    //���� �������̵��Ͽ� ���
    public virtual void Input(bool val)
    {
        IsActive = val != reverse;
    }

    //�⺻ ���
    //target�鿡 ��ȣ����
    public virtual void output()
    {
        foreach(GameObject go in target)
        {
            go.GetComponent<Trigger>().Input(IsActive);
        }
    }
}
