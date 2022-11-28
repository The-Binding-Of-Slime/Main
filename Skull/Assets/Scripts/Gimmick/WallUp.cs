using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WallUp : Trigger
{
    [Header("-작동시 이동량")]
    public Vector2 reverseVector;
    [Header("-이동속도 (0 ~ 1)")]
    public float speed;
    [Header("-작동시 콜라이더 비활성화여부")]
    public bool colliderControll;
    Vector2 originVector;
    Vector2 movedVector;
    float sibal;

    float positionValue
    {
        get { return sibal; }
        set {
            if(value > 2f)
            {
                sibal = 2f;
            }
            else if(value <= 0f)
            {
                sibal = 0f;
            }
            else
            {
                sibal = value;
            }
        }
    }
    protected override void Start()
    {
        base.Start();
        if (defaultActive)
        {
            movedVector = transform.position;
            originVector = movedVector + reverseVector;
        }
        else
        {
            originVector = transform.position;
            movedVector = originVector + reverseVector;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!IsActive)
        {
            //transform.position = Vector2.Lerp(transform.position, movedVector,speed);
            positionValue -= speed * Time.deltaTime;
        }
        else
        {
            //transform.position = Vector2.Lerp(transform.position, originVector, speed);
            positionValue += speed * Time.deltaTime;
        }
        transform.position = movedVector * positionValue + originVector * (1f - positionValue);
    }

    public override void Input(bool val)
    {
        base.Input(val);
        run();
    }

    public void run()
    {
        if (colliderControll)
        {
            if (IsActive)
            {
                //gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<Collider2D>().enabled = true;
            }
            else
            {
                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
