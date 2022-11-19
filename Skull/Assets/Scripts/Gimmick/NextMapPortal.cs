using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class NextMapPortal : MonoBehaviour, Interaction
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Interaction()
    {
        FindObjectOfType<GameManager>().NextMap();
    }
}
