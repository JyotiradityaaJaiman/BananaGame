using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// add if using AI for navigation

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10;
    Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                // move enemy towards player
                agent.SetDestination(target.position);

                // rotate enemy so it always faces straight
                /* This causes the following debug error:
                    Look rotation viewing vector is zero
                    UnityEngine.Quaternion:LookRotation (UnityEngine.Vector3)
                   TODO: FIX THIS
                */
                Quaternion lookRotation = Quaternion.LookRotation(Vector3.zero);
                transform.rotation = lookRotation;

                // Flip the sprite based on the player's position relative to the enemy
                Vector3 direction = target.position - transform.position;
                direction.Normalize();
                if (direction.x < 0)
                {
                    sr.flipX = true;
                }
                else if (direction.x > 0)
                {
                    sr.flipX = false;
                }
            }

                if (distance <= agent.stoppingDistance)
                {
                    // TODO: attack the target
                }
            }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
