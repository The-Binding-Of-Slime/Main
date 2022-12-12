using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChainAttack : HitBox
{
    GameObject[] his = new GameObject[10];
    GameObject startPos;
    Vector2 targetPos;

    protected override void Start()
    {
        startPos = gameObject;
        targetPos = transform.position;
        StartCoroutine(ChainStart(5, 0.1f));
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, targetPos, Time.deltaTime * 20);
    }

    void Chain()
    {
        if(startPos == null)
        {
            startPos = gameObject;
        }

        //피격가능대상 선별
        Collider2D[] cols = Physics2D.OverlapCircleAll(startPos.transform.position, 3);
        GameObject[] gameObjects = new GameObject[cols.Length];
        int k = 0;
        for(int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject.GetComponent<Victim>() != null && !cols[i].gameObject.CompareTag(transform.tag) && cols[i].gameObject != startPos && Array.IndexOf(his, cols[i].gameObject) == -1)
            {
                gameObjects[k++] = cols[i].gameObject;
            }
        }
        
        //피격가능대상 개수 확인
        GameObject min = gameObjects[0];
        int n = 0;
        foreach(GameObject g in gameObjects)
        {
            if(g == null)
            {
                break;
            }
            n++;
        }
        if(n == 0)
        {
            return;
        }

        Debug.Log(gameObjects[0]);
        //가장 가까운대상 탐지
        if (n > 1)
        {
            for (int i = 1; gameObjects[i] != null; i++)
            {
                if (Vector2.Distance(startPos.transform.position, min.transform.position) > Vector2.Distance(startPos.transform.position, gameObjects[i].transform.position))
                {
                    min = gameObjects[i];
                }
            }
        }
        
        //대미지 계산 및 시작위치 변경
        min.GetComponent<Victim>().TakeDamage(damage);
        //transform.position = min.transform.position;
        his[Array.IndexOf(his, startPos) + 1] = min;
        //Debug.DrawLine(min.transform.position, startPos.transform.position,Color.red,0.1f);
        startPos = min;
        targetPos = min.transform.position;
    }

    IEnumerator ChainStart(int chainCount,float delay)
    {
        Debug.Log("-----------------------");
        for(int i = 0; i < chainCount; i++)
        {
            yield return new WaitForSeconds(delay);
            Chain();
        }
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
