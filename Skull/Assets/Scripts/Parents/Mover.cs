using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour,Stunable
{
    [SerializeField]
    protected float maxSpeed = 5;
    [SerializeField]
    protected float moveSpeed = 5;
    [SerializeField]
    protected float jumpPower = 7;
    protected Rigidbody2D Rigid { get; private set; }
    //float timer = 0f;

    protected virtual void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //timer -= Time.deltaTime;
    }

    public void Move(float speed)
    {
        if(Mathf.Abs(Rigid.velocity.x) <= maxSpeed/* && timer <= 0f*/)
        {
            Rigid.AddForce(30 * moveSpeed * speed * Vector3.right);
        }
    }

    protected bool CheckIsGround()
    {
        RaycastHit2D rayhit;
        rayhit = Physics2D.Raycast(transform.position + Vector3.down * 1.2f, Vector2.down, 0.2f);
        Debug.DrawLine(transform.position + Vector3.down * 1.2f, transform.position + Vector3.down * 1.2f + Vector3.down * 0.2f,Color.black,0.2f);
        //Debug.DrawRay(transform.position + Vector3.down * 1.2f, Vector3.down * 0.4f, Color.red);
        bool isGround = rayhit.collider != null && !rayhit.collider.isTrigger;
        return isGround;
    }

    public void SetSpeed(float moveSpeed,float jumpPower)
    {
        maxSpeed = moveSpeed;
        this.moveSpeed = moveSpeed;
        this.jumpPower = jumpPower;
    }

    protected virtual bool Jump()
    {
        if (CheckIsGround())
        {
            Rigid.velocity = new Vector3(Rigid.velocity.x, jumpPower);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Stun(float time)
    {
        //timer = time;
    }
}
