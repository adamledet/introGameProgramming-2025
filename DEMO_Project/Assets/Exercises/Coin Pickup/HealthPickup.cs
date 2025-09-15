using Exercises;
using UnityEngine;

//Adam Ledet
public class HealthPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<SimplePlayerController>();
        if (player)
        {
            player.GetComponent<HealthDecay>().Increment();
            Destroy(this.gameObject);
        }
    }
}
