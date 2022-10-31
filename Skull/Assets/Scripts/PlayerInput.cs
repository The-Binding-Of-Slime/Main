using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//입력관련 담당
//PlayerControl에서 참조하는 클래스
public class PlayerInput : MonoBehaviour
{
    public KeyCode jumpKey;
    public KeyCode interactionKey;
    public KeyCode skill1Key;
    public KeyCode skill2Key;
    public float Hor { get; private set; }
    public float Ver { get; private set; }
    public bool GetHorDown { get; private set; }
    public bool GetVerDown { get; private set; }
    public bool GetJumpDown { get; private set; }
    public bool GetInteractionDown { get; private set; }
    public bool GetInteractionStay { get; private set; }

    public bool GetSkill1Down { get; private set; }
    public bool GetSkill1Stay { get; private set; }

    public bool GetSkill2Down { get; private set; }
    public bool GetSkill2Stay { get; private set; }
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
        GetSkill1Down = Input.GetKeyDown(skill1Key);
        GetSkill1Stay = Input.GetKey(skill1Key);
        GetSkill2Down = Input.GetKeyDown(skill2Key);
        GetSkill2Stay = Input.GetKey(skill2Key);
    }

    public void Initialize()
    {
        Hor = 0;
        Ver = 0;
        GetHorDown = false;
        GetVerDown = false;
        GetJumpDown = false;
        GetInteractionDown = false;
        GetInteractionStay = false;
    }
}
