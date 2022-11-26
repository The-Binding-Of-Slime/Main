using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    [Header("-도움말")]
    public GameObject helpUi;
    public GameObject helpKeyUi;
    public Text helpText;
    [Header("-스테이지 배열")]
    public GameObject[] maps;
    [Header("-암전효과")]
    public Image blackCanvas;
    [Header("-배경1")]
    public GameObject outSideBackGround;
    [Header("-배경2")]
    public GameObject CaveBackGround;
    public GameObject PauseMenu;
    [Header("-레벨별 필요EXP(누적X)")]
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

    //도움말 출력용
    public void ShowHelp(string s)
    {
        helpUi.SetActive(true);
        helpText.text = s;
    }

    //도움말 닫기
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

    //다음스테이지 호출
    public void NextMap()
    {
        if (!(nowMap < maps.Length - 1) || isEnter)
        {
            return;
        }
        isEnter = true;
        StartCoroutine(BlackDown());
    }

    //스테이지 전환시 장면전환 효과(암전)
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

    //일시정지
    void Pause()
    {
        inputSys.Initialize();
        inputSys.enabled = false;
        PauseMenu.SetActive(true);
    }

    //재생
    public void UnPause()
    {
        inputSys.enabled = true;
        PauseMenu.SetActive(false);
    }

    //메인화면으로 돌아가기
    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }

    //exp획득 및 레벨업 호출
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