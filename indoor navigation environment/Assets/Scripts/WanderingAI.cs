﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent m_Agent;
    private Animator m_Animator;
    private float timer;

    // Use this for initialization
    private void OnEnable()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            m_Agent.SetDestination(newPos);
            timer = 0;
            
        }
            
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}