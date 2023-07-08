using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float lookRadius = 10;
    public float movementSpeed = 5f;
    public int damageAmount = 10;

    private Transform player;
    private SpriteRenderer sr;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if (player != null)
        {
            
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= lookRadius)
            {
                Vector3 direction = player.position - transform.position;
            direction.Normalize();

            transform.Translate(direction * movementSpeed * Time.deltaTime);

            // Flip the sprite based on the player's position relative to the enemy
            if (direction.x < 0)
            {
                sr.flipX = true;
            }
            else if (direction.x > 0)
            {
                sr.flipX = false;
            }
            }
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
