using UnityEngine;

public class Rebound : MonoBehaviour
{
    [SerializeField] Transform player;

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.position = new Vector3();
        player.GetComponent<CharacterController>().enabled = true;
    }
}
