using UnityEngine;
using UnityEngine.InputSystem;

namespace HideAndCatch
{
    public class EnemySeesPlayer : MonoBehaviour
    {
        private GameObject player;
        bool playerDetected;
        [SerializeField] float height;// Height offset for ray. Assume enemy and player are same height
        [SerializeField] float visionCone;// When 0, enemy sees perfectly at its sides. When 1, player must be directly in front of enemy to be seen
        private Vector3 heightOffset;
        string state;
        [SerializeField] Patrol patrolScript;

        private void Start()
        {
            player = null;
            heightOffset = new Vector3(0, height, 0);
            if(visionCone <0) { visionCone = 0; }
            state = "Patrol";
        }

        private void Update()
        {

            if(player != null)
            {
                Vector3 dirToPlayer = (player.transform.position - transform.position);
                Debug.DrawRay((transform.position+heightOffset), (dirToPlayer), Color.red);

                if (Physics.Raycast((transform.position+heightOffset), (dirToPlayer), out RaycastHit hit))
                {
                    var p = hit.collider.GetComponent<PlayerInput>();
                    float dotProduct = Vector3.Dot(transform.forward, dirToPlayer);
                    if(p!=null && dotProduct>visionCone)
                    {
                        if(state=="Patrol")
                        {
                            patrolScript.StartChase(player);
                            state = "Chase";
                        }
                    }
                    else
                    {
                        if(state=="Chase")
                        {
                            patrolScript.StartSearch(player.transform.position);
                            state = "Patrol";
                        }
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var p = other.GetComponent<PlayerInput>();
            if (p != null)
            {
                player = p.gameObject;
                //Debug.Log("PLAYER ENTERED");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var p = other.GetComponent<PlayerInput>();
            if (p != null)
            {
                player = null;
                //Debug.Log("PLAYER EXITED");
            }
        }
    }
}
