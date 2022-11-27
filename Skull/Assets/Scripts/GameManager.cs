using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    [Header("-����")]
    public GameObject helpUi;
    public GameObject helpKeyUi;
    public Text helpText;
    [Header("-�������� �迭")]
    public GameObject[] maps;
    [Header("-����ȿ��")]
    public Image blackCanvas;
    [Header("-���1")]
    public GameObject outSideBackGround;
    [Header("-���2")]
    public GameObject CaveBackGround;
    public GameObject PauseMenu;
    [Header("-������ �ʿ�EXP(����X)")]
    public float[] MaxExp;
    InputSystem inputSys;
    float blackCanvasAlpha;
    bool isEnter = false;
    GameObject player;
    Vector3 spawnPoint;
    int nowMap = 0;
    float exp = 0;
    int level = 1;
    public int Gold
    {
        get;
        private set;
    }

    void Start()
    {
        Gold = 0;
        for (int i = 1; i < maps.Length; i++)
        {
            maps[i].SetActive(true);
        }
        for (int i = 1; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }
        if (maps.Length != 0)
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

        player = FindObjectOfType<PlayerControl>().gameObject;
        inputSys = GetComponent<InputSystem>();
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (blackCanvas != null)
        {
            blackCanvas.color = new Color(blackCanvas.color.r, blackCanvas.color.g, blackCanvas.color.b, blackCanvas.color.a + ((blackCanvas.color.a + blackCanvasAlpha) / 2f - blackCanvas.color.a) * Time.deltaTime * 8);
        }
    }

    //���� ��¿�
    public void ShowHelp(string s)
    {
        helpUi.SetActive(true);
        helpText.text = s;
    }

    //���� �ݱ�
    public void CloseHelp()
    {
        helpText.text = "";
        helpUi.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.position = spawnPoint;
        }
    }

    //������������ ȣ��
    public void NextMap()
    {
        if (!(nowMap < maps.Length - 1) || isEnter)
        {
            return;
        }
        isEnter = true;
        StartCoroutine(BlackDown());
    }

    //�������� ��ȯ�� �����ȯ ȿ��(����)
    IEnumerator BlackDown()
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

    //�Ͻ�����
    void Pause()
    {
        inputSys.Initialize();
        inputSys.enabled = false;
        PauseMenu.SetActive(true);
    }

    //���
    public void UnPause()
    {
        inputSys.enabled = true;
        PauseMenu.SetActive(false);
    }

    //����ȭ������ ���ư���
    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }

    //expȹ�� �� ������ ȣ��
    public void GetExp(float expup)
    {
        exp += expup;
        while (exp >= MaxExp[level])
        {
            exp -= MaxExp[level];
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;

    }
}