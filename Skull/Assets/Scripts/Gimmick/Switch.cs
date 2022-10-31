using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

//상호작용 레버 구현
public class Switch : Trigger,Interaction
{
    public Sprite onSprite;
    public Sprite offSprite;
    SpriteRenderer render;
    float timer=0;
    protected override void OnEnable()
    {
        render = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
    }

    public void Interaction()
    {
        if (timer <= 0f)
        {
            timer = 1f;
            Input(!IsActive);
            output();
        }
    }

    public override void Input(bool val)
    {
        base.Input(val);
        if (IsActive)
        {
            render.sprite = onSprite;
        }
        else
        {
            render.sprite = offSprite;
        }
    }
}
