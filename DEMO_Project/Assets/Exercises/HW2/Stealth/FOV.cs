using UnityEngine;

public class FOV : MonoBehaviour
{
    [SerializeField] GameObject marker;
    [SerializeField] Transform player;
    [SerializeField] bool isInRange;

    // Update is called once per frame
    void Update()
    {
        var e = transform.forward;
        var p = player.position - transform.position;
        var angle = Vector3.Angle(e, p);
        Debug.Log($"Angle:  {angle}");
        marker.SetActive(angle < 30);
    }
}
