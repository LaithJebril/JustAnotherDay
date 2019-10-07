using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite[] PlayerSP;
    SpriteRenderer Player_SPR;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    public void Animation(int Anim_Index)
    {
        if (Anim_Index ==0)
        {
            Player_SPR.sprite = PlayerSP[0];
        }
        else if (Anim_Index ==1)
        {
            Player_SPR.sprite = PlayerSP[1];
        }
        else//=3
        {
            Player_SPR.sprite = PlayerSP[2];
        }
    }
    public void AnimatioSetActive(bool Active)
    {
        animator.enabled = Active;
    }
}
