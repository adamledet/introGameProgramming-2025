using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] List<Transform> points;
    int current;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent.SetDestination(points[current].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            current++;
            if (current == points.Count)
            {
                current = 0;
            }
            agent.SetDestination(points[current].position);
        }
        if(agent.velocity.sqrMagnitude>0)
        {
            animator.SetFloat("Speed",agent.velocity.sqrMagnitude);
        }
    }
}
