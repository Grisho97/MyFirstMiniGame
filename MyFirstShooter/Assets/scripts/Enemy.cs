using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{
   
    private NavMeshAgent _pathfinder;
    private Transform _target;

    private float _attackDistanceT = 1.5f;
    private float _timeBetweenAttacks = 1;
    private float _nextAttackTime;
    protected override void Start()
    {
        base.Start();
        _pathfinder = GetComponent<NavMeshAgent>();
       _target = GameObject.FindWithTag("Player").transform;


       StartCoroutine(UpdatePath());
    }

    private void Update()
    {
        if (Time.time > _nextAttackTime)
        {
            float sqrDistanceToTarget = (_target.position - transform.position).sqrMagnitude;
                    if (sqrDistanceToTarget < Mathf.Pow(_attackDistanceT,2))
                    {
                        _nextAttackTime = Time.time + _timeBetweenAttacks;
                       // StartCoroutine(Attack())
                    }
        }
        
    }

   // IEnumerator Attack()
   // {
        
  //  }
        
    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;
        while (_target != null)
        {
            Vector3 targetPosition = new Vector3(_target.position.x, 0, _target.position.z);
            if (!dead)
            {
                _pathfinder.SetDestination(targetPosition);
            }
            
            yield return new WaitForSeconds(refreshRate);
        }
    }
}

