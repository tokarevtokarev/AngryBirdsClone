using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 4f;
    public static int EnemiesAlive = 0;


    // Start is called before the first frame update
    void Start()
    {
        EnemiesAlive++;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.relativeVelocity.magnitude > health) {
            Die();
        }
    }

    void Die() {
        EnemiesAlive--;
        Destroy(gameObject);

        if (GameManager.GM != null) {
            if (EnemiesAlive <= 0) {
                GameManager.GM.GameOver = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
