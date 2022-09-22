using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject helpUi;
    public GameObject helpKeyUi;
    public Text helpText;
    public GameObject questManager;
    public GameObject[] maps;
    public bool isDebuging;
    public Image blackCanvas;
    public GameObject outSideBackGround;
    public GameObject CaveBackGround;
    public GameObject PauseMenu;
    PlayerInput inputSys;
    float blackCanvasAlpha;
    bool isEnter = false;
    GameObject player;
    Vector3 spawnPoint;
    int nowMap = 0;
    void Start()
    {
        for (int i = 1; i < maps.Length; i++)
        {
            maps[i].SetActive(true);
        }
        for (int i = 1; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }
        if (!isDebuging)
        {
            maps[0].SetActive(true);
            if (maps[0].name[1] == '1')
            {
                outSideBackGround.SetActive(true);
                CaveBackGround.SetActive(false);
            }
            else
            {
                outSideBackGround.SetActive(false);
                CaveBackGround.SetActive(true);
            }
        }
        else
        {
            maps[maps.Length-1].SetActive(true);
        }

        player = FindObjectOfType<PlayerControll>().gameObject;
        inputSys = GetComponent<PlayerInput>();
        spawnPoint = GameObject.Find("Spawn Point").transform.position;
        player.transform.position = spawnPoint;

        PlayerPrefs.SetFloat("PlayerHp", 1);
        PlayerPrefs.SetFloat("PlayerDamage", 1);
        PlayerPrefs.SetFloat("PlayerMoveSpeed", 1);
        PlayerPrefs.SetFloat("PlayerAttackDelay", 1);
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        blackCanvas.color = new Color(blackCanvas.color.r, blackCanvas.color.g, blackCanvas.color.b, blackCanvas.color.a + ((blackCanvas.color.a + blackCanvasAlpha) / 2f - blackCanvas.color.a) * Time.deltaTime * 8);
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
        if(!(nowMap < maps.Length-1) || isEnter) {
            return;
        }
        isEnter = true;
        StartCoroutine(blackDown());
    }

    IEnumerator blackDown()
    {
        blackCanvasAlpha = 1.3f;
        yield return new WaitForSeconds(1f);

        maps[nowMap].SetActive(false);
        nowMap++;
        maps[nowMap].SetActive(true);
        spawnPoint = GameObject.FindWithTag("Respawn").transform.position;
        player.transform.position = spawnPoint;
        if (maps[nowMap].name[1] == '1')
        {
            outSideBackGround.SetActive(true);
            CaveBackGround.SetActive(false);
        }
        else
        {
            outSideBackGround.SetActive(false);
            CaveBackGround.SetActive(true);
        }

        blackCanvasAlpha = 0f;
        isEnter = false;
    }

    void Pause()
    {
        inputSys.reset();
        inputSys.enabled = false;
        PauseMenu.SetActive(true);
    }

    public void UnPause()
    {
        inputSys.enabled=true;
        PauseMenu.SetActive(false);
    }

    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }
}