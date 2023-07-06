using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // movement values
    public float speed, jumpForce;
    public float groundDist;
    private Vector2 moveInput;
    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    // health & magic values
    public int maxHealth = 100;
    public int currentHealth;
    public int maxMagic = 20;
    public int currentMagic;
    public HealthBar healthBar;
    public MagicBar magicBar;


    // Start is called before the first frame update
    void Start()
    {
        // for movement
        rb = GetComponent<Rigidbody>();
        // for UI
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        currentMagic = maxMagic; 
        magicBar.SetMaxMagic(currentMagic);
    }

    // Update is called once per frame
    void Update()
    {
        // ensures that character stays above ground
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
        // movement
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();
        rb.velocity = new Vector3(moveInput.x * speed, rb.velocity.y , moveInput.y * speed);
        // flips the character
        if (moveInput.x != 0 && moveInput.x < 0)
        {
            sr.flipX = false;
        }
        else if (moveInput.x != 0 && moveInput.x > 0)
        {
            sr.flipX = true;
        }

        // health and magic bars
        if (Input.GetKeyDown(KeyCode.Space)){HealthGone(20);}
        if (Input.GetKeyDown(KeyCode.Space)){MagicGone(3);}

    }


    // helps with reducing health
    void HealthGone(int health){
        currentHealth-=health;
        healthBar.SetHealth(currentHealth);
    }

    // helps with reducing magic
    void MagicGone(int magic){
        currentMagic-=magic;
        magicBar.SetMagic(currentMagic);
    }
}
