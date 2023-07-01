using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed, jumpForce;
    public float groundDist;

    private Vector2 moveInput;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //terrain stuff
        
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if(Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        { 
            if (hit.collider != null) 
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }
        

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * speed, rb.velocity.y , moveInput.y * speed);

        
        if (moveInput.x != 0 && moveInput.x < 0)
        {
            sr.flipX = false;
        }
        else if (moveInput.x != 0 && moveInput.x > 0)
        {
            sr.flipX = true;
        }
        
    }
}
