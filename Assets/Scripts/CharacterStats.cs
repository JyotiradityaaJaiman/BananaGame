using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth {get; private set;}
    public HealthBar healthBar;
    public Stat damage;
    public Stat armour;
    public int maxMagic = 20;
    public int currentMagic {get; private set;}
    public MagicBar magicBar;

    void Awake ()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(currentHealth);
        }
        currentMagic = maxMagic;
        if (magicBar != null)
        {
            magicBar.SetMaxMagic(currentMagic);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            spell(6);
        }
    }

    public void takeDamage (int damage){
        //armour resists damage
        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);


        // damage removed from health
        currentHealth -= damage;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Debug.Log("<color=red>" + transform.name + " takes " + damage + " damage</color>");
            Die();
            return;
        }
        Debug.Log("<color=red>" + transform.name + " takes " + damage + " damage</color>");
    }

    public void spell (int magic){
        // damage removed from health
        if (currentMagic < magic)
        {
            Debug.Log("<color=cyan>" + transform.name + " does not have enough magic</color>");
            return;
        }
        currentMagic -= magic;
        if (magicBar != null)
        {
            magicBar.SetMagic(currentMagic);
        }
        Debug.Log("<color=cyan>" + transform.name + " uses spell, consuming " + magic + " magic</color>");

    }

    public virtual void Die()
    {
        Debug.Log("<color=red>" + transform.name + " died</color>");
    }
}
