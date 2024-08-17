using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    //direction
    float horizontalMove = 0f;
    //speed
    [SerializeField]
    public float runSpeed = 40f;
    public float boost = 1;
    bool jump = false;
    bool crouch = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            boost = 2;
        }

        else
        {
            boost = 1;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * boost;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
