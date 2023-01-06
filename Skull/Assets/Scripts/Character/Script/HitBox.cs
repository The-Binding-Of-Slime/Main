using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public float damage { protected get; set; }
    public float destroyTimer { protected get; set; }
    public float activeDelay { protected get; set; }

    Collider2D col;

    protected virtual void Start()
    {
        StartCoroutine(Timer(MathF.Max(destroyTimer,0.1f)));
        StartCoroutine(ColliderTimer());
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(transform.tag) && collision.gameObject.GetComponent<Victim>() != null)
        {
            collision.gameObject.GetComponent<Victim>().TakeDamage(damage);
        }
    }

    IEnumerator Timer(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    IEnumerator ColliderTimer()
    {
        yield return new WaitForSeconds(activeDelay);
        col.enabled = true;
    }
}
