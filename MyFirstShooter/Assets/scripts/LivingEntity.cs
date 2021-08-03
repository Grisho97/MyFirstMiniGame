using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamage
{
    public float startingHealth;
    protected float Health;
    protected bool dead;

    public event System.Action OnDeath;
    protected virtual void Start()
    {
        Health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        Health -= damage;
        if (Health <= 0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }
}
