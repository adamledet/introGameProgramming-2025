using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HideAndCatch
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] NavMeshAgent agent;
        [SerializeField] List<GameObject> patrolPoints;
        private int currentPatrolPath;
        [SerializeField] float destinationPadding;
        [SerializeField] float patrolRestTime;
        private bool reachedPatrolPoint;
        [SerializeField] Animator animator;
        string state;

        GameObject player;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            reachedPatrolPoint = false;
            agent.SetDestination(patrolPoints[0].transform.position);
            currentPatrolPath = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if(agent.remainingDistance < destinationPadding && !reachedPatrolPoint)
            {
                if (player ==null)
                {
                    StartCoroutine(SetNextPosition());
                }
                else
                {
                    agent.SetDestination(player.transform.position);
                }
            }
            //Debug.Log(agent.velocity.magnitude);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }

        IEnumerator SetNextPosition()
        {
            reachedPatrolPoint = true;
            yield return new WaitForSeconds(patrolRestTime);
            if (currentPatrolPath == patrolPoints.Count - 1)
            {
                currentPatrolPath = 0;
            }
            else
            {
                currentPatrolPath++;
            }
            agent.SetDestination(patrolPoints[currentPatrolPath].transform.position);
            reachedPatrolPoint = false;
        }

        void OnFootstep()
        {
            return;
        }

        public void StartChase(GameObject p)
        {
            player = p;
        }

        public void StartSearch(Vector3 lastKnownPosition)
        {
            player = null;
            agent.SetDestination(lastKnownPosition);
        }
    }
}
