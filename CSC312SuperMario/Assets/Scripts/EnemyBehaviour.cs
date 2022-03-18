using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float range = 0.1f;
    private bool movingRight = true;

    [SerializeField] private float attackDamage = 1f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private float damage = 1f;


    private float health = 1f;
    [SerializeField] private float maxHealth = 1f;
    public Transform wallDetection;

    private void Start() {
        health = maxHealth;
    }

    public void takeDamage(){
        health -= damage;
        if (health <= 0){
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
    


        // if(groundInfo.collider == true){
        //     if(movingRight){
        //         transform.eulerAngles = new Vector3(0, -180, 0);
        //         movingRight = false;
        //     } else {
        //         transform.eulerAngles = new Vector3(0, 0, 0);
        //         movingRight = true;
        //     }
        // }
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
            other.gameObject.GetComponent<PlayerHealth>().updateHealth(-attackDamage);
            canAttack = 0f;
            } else {
                canAttack += Time.deltaTime;
            }
        }
    }

    void OnCollisionStay2D(Collision2D other){
        if (other.gameObject.tag == "Player"){
            if(attackSpeed <= canAttack){
            other.gameObject.GetComponent<PlayerHealth>().updateHealth(-attackDamage);
            canAttack = 0f;
            } else {
                canAttack += Time.deltaTime;
            }
        }
    }

}
