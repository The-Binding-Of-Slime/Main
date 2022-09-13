using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject helpUi;
    public GameObject helpKeyUi;
    public Text helpText;
    public GameObject questManager;
    public GameObject[] maps;
    GameObject player;
    Vector3 spawnPoint;
    int nowMap = 0;
    void Start()
    {
        for(int i = 1; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }
        maps[0].SetActive(true);

        player = FindObjectOfType<PlayerControll>().gameObject;
        spawnPoint = GameObject.Find("Spawn Point").transform.position;
        player.transform.position = spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            helpKeyUi.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.F1))
        {
            helpKeyUi.SetActive(false);
        }
    }

    public void showHelp(string s)
    {
        helpUi.SetActive(true);
        helpText.text = s;
    }

    public void closeHelp()
    {
        helpText.text = "";
        helpUi.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            player.transform.position = spawnPoint;
        }
    }

    public void nextMap()
    {
        if(!(nowMap < maps.Length-1)) {
            return;
        }
        maps[nowMap].SetActive(false);
        nowMap++;
        maps[nowMap].SetActive(true);
        spawnPoint = GameObject.FindWithTag("Respawn").transform.position;
        player.transform.position = spawnPoint;
    }
}
