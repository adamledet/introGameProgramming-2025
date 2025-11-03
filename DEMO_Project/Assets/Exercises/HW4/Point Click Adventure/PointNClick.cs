using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PointNClick : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask layer;

    // Update is called once per frame
    void OnClick()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        //Debug.Log(mousePos);

        Ray ray = mainCamera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, layer))
        {
            var position = hit.point;
            agent.SetDestination(position);
        }
    }

    void OnFootstep()
    {
        Debug.Log("Quack");
        return;
    }
    
    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }
}
