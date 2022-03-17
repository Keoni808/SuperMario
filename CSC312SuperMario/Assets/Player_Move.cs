using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    public float moveX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove(){
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        //ANIMATIONS
        //PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false){
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true){
            FlipPlayer();
        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump(){
        //JUMPING CODE
    }

    void FlipPlayer(){

    }
}
