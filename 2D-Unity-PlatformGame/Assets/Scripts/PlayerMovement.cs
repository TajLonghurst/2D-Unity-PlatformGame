using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool Crouch = false;
    public Animator animator;

    public SoundManeger soundManeger;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
            soundManeger.JumpSound.Play();
        }

        if(Input.GetButtonDown("Crouch"))
        {
            Crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            Crouch = false;
        }
    }
    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }
    public void OnCrouch(bool isCrouching)
    {
        animator.SetBool("Crouch", isCrouching);  
    }
    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, Crouch, jump);
        jump = false; 
    }
}
