using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask collisionMask;
    private float _speed = 10;
    private float damage = 1;
  
    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
    private void Update()
    {
        float moveDistance = _speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        IDamage damageObject = hit.collider.GetComponent<IDamage>();
        if (damageObject != null)
        {
            damageObject.TakeHit(damage, hit);
        }
        GameObject.Destroy(gameObject);
    }
}
