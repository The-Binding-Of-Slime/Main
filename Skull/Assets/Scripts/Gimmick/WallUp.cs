using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUp : Trigger
{
    public Vector2 reverseVector;
    public float speed;
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

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
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

    public override void input(bool val)
    {
        base.input(val);
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
