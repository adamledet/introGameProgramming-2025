using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class PatrolChase : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] float chaseRange;
    [SerializeField] float attackRange;
    [SerializeField] float attackCooldown;
    float attackTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePatrolling()
    {
        if (IsPlayerInRange(chaseRange))
        {
            TransitionTo(State.Chase);
            return;
        }
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            
        }
    }

    void UpdateChase()
    {
        if (!IsPlayerInRange(chaseRange * 1.5f))
        {
            TransitionTo(State.Idle);
            return;
        }
        agent.destination = player.position;
    }

    void UpdateAttack()
    {
        transform.LookAt(player.position);
        agent.ResetPath();

        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            attackTimer = attackCooldown;
        }
        if (!IsPlayerInRange(attackRange))
        {
            TransitionTo(State.Chase);
        }
    }
    
    bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.position) <= range;
    }
}
