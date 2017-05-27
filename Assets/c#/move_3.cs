﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_3 : MonoBehaviour
{
    GameObject player;
    PlayerMovement playerScript;


    public float movePower = 6f;
    public float jumpPower = 20f;
    public int maxHealth = 3;
 
    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputJump = false;

    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;
   public bool doubleJump;
    public int JumpConut;
    public bool isJumping;

    public void LeftClick ()
    {

    }
    public void RightClick ()
    {

    }
    public void JumpClick ()
    {

    }

   
    public void Update()
    {
        if ((!inputRight && !inputLeft))
        {
            animator.SetBool("isMoving", false);
        }
        else if (inputLeft)
        {
            animator.SetBool("isMoving", true);
            transform.localScale = new Vector3(-1, 1, 1);//왼쪽 이동
        }
        else if (inputRight)
        {
            animator.SetBool("isMoving", true);//오른쪽 이동
            transform.localScale = new Vector3(1, 1, 1);

        }
        if(inputJump &&(!animator.GetBool ("isJumping") || (animator.GetBool ("isJumping") && doubleJump))) {
            JumpConut++;
            isJumping = true;
            inputJump = false;
            animator.SetBool("isJumping", true);
            animator.SetTrigger("doJumping");

            if(JumpConut == 2)
            {
                doubleJump = false;
                JumpConut = 0;
            }

        }
    }
}