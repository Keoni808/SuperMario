using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    public float moveSpeed = 1f;
    public float range = 0.1f;
    private bool movingRight = true;
    
    public Transform wallDetection;
    
    private bool isDead;
    public float goombaHealth = 1f;
    public float damageTaken = 1f;

    private void Start() {
        isDead = false;
    }

    public void takeDamage(){
        goombaHealth -= damageTaken;
        if (goombaHealth == 0){
            isDead = true;
            Destroy(gameObject);
        }
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D rightInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, range);
        RaycastHit2D leftInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, range);

        if(rightInfo.collider == true && movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180,0);
            movingRight = false;
        } 

        if(leftInfo.collider == true && !movingRight) 
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        } 
    }

    void OnCollisionEnter2D(Collision2D other){
        takeDamage();
    }

    void OnCollisionStay2D(Collision2D other){
        
    }

}
