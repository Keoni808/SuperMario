using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    public float horizontalMove = 0.0f;
    public float runSpeed = 5.0f;
    private bool jump;
    private bool crouch;

    public CharacterController2D controller;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        PlayerRaycast();

        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crouch")){
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }
        
    }

    public void OnLanding (){
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void PlayerRaycast(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if(hit.collider.tag == "Enemy" && hit.distance < .1){
            Destroy(hit.collider.gameObject);
        }
    }

}
