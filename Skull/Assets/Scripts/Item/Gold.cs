using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    GoldManager goldManager;
    private void Start()
    {
        goldManager = FindObjectOfType<GoldManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            goldManager.AddMoney(1);
            Destroy(gameObject);
        }
    }
}
