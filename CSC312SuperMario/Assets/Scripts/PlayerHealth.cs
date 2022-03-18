using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private float health = 0f;
    [SerializeField] private float maxHealth = 1f;

    private void Start() {
        health = maxHealth;
    }

    public void updateHealth(float mod){
        health += mod;

        if (health > maxHealth) {
            health = maxHealth;
        } else if (health <= 0f){
            health = 0f;
            Destroy(gameObject);
        }
    }
}
