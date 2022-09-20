using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Help : MonoBehaviour
{
    GameManager gameManager;
    [TextArea]
    public string HelpText;
    void start()
    {
        //HelpText = HelpText.Replace("\\n", "\n");
    }

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerControll>() != null)
        {
            gameManager.showHelp(HelpText);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerControll>() != null)
        {
            gameManager.closeHelp();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
