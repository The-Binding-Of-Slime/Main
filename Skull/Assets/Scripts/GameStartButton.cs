using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    public Image blackCanvas;
    float blackCanvasAlpha = 0f;
    bool isClicked = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (blackCanvas != null)
        {
            blackCanvas.color = new Color(blackCanvas.color.r, blackCanvas.color.g, blackCanvas.color.b, blackCanvas.color.a + ((blackCanvas.color.a + blackCanvasAlpha) / 2f - blackCanvas.color.a) * Time.deltaTime * 8);
            if (blackCanvasAlpha == 0f && blackCanvas.color.a <= 0.01f)
            {
                blackCanvas.gameObject.SetActive(false);
            }
            else
            {
                blackCanvas.gameObject.SetActive(true);
            }
        }
    }

    public void ReStart()
    {
        /*        if (!isClicked)
                {
                    isClicked = true;*/
        StartCoroutine(loadLevel());
        //}
    }

    IEnumerator loadLevel()
    {
        blackCanvasAlpha = 1.3f;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
