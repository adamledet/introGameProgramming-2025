using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var bullet = other.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Debug.Log("HIT");
            Destroy(other.gameObject);
            bullet.player.AddScore();
            Destroy(this.gameObject);
        }
    }
}
