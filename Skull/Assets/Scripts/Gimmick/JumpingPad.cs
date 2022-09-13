using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPad : MonoBehaviour
{
    public float jumpPower;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.GetComponentInParent<Rigidbody2D>().velocity = Vector3.up * jumpPower;
    }
}
