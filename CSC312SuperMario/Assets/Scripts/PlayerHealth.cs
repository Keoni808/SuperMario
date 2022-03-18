using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool hasDied;
    private float health = 0.0f;

    private void Start() {
        hasDied = false;
    }

    private void Update() {
        if(gameObject.transform.position.y < -3){
            hasDied = true;
        }
        playerDies();
    }

    public void updateHealth(){

    }

    void playerDies(){
        if(hasDied){
            Destroy(gameObject);
        }
    }
}
