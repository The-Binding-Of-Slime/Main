using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상호작용 관련 오브젝트 구현용

[ExecuteInEditMode]
public class Trigger : MonoBehaviour
{
    [Header("-신호전달 타겟")]
    public GameObject[] target;
    [Header("-기본 입력")]
    public bool defaultActive;
    [Header("-입력반전 여부")]
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

    //기본 입력
    //다른 Trigger의 output 이나 플레이어에 의해 호출됨
    //보통 오버라이딩하여 사용
    public virtual void Input(bool val)
    {
        IsActive = val != reverse;
    }

    //기본 출력
    //target들에 신호전달
    public virtual void output()
    {
        foreach(GameObject go in target)
        {
            go.GetComponent<Trigger>().Input(IsActive);
        }
    }
}
