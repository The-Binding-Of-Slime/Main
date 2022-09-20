using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode jumpKey;
    public KeyCode interactionKey;
    public float Hor { get; private set; }
    public float Ver { get; private set; }
    public bool GetHorDown { get; private set; }
    public bool GetVerDown { get; private set; }
    public bool GetJumpDown { get; private set; }
    public bool GetInteractionDown { get; private set; }
    public bool GetInteractionStay { get; private set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hor = Input.GetAxis("Horizontal");
        Ver = Input.GetAxis("Vertical");
        GetHorDown = Input.GetAxisRaw("Horizontal") != 0;
        GetVerDown = Input.GetAxisRaw("Vertical") != 0;
        GetJumpDown = Input.GetKeyDown(jumpKey);
        GetInteractionDown = Input.GetKeyDown(interactionKey);
        GetInteractionStay = Input.GetKey(interactionKey);
    }
}
