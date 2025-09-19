using System;
using Unity.VisualScripting;
using UnityEngine;

public class Backstab : MonoBehaviour
{
    [SerializeField] GameObject marker;
    [SerializeField] Transform player;

    // Update is called once per frame
    void Update()
    {
        var e = transform.forward;
        var p = player.position - transform.position;
        var dot = Vector3.Dot(e, p);
        Debug.Log($"Dot: {dot}");
        marker.SetActive(dot < -0.75 && InRange(dot, 2));
    }

    private bool InRange(float dot, float range)
    {
        //return (p.magnitude < range);
        return Vector3.Distance(transform.position, player.position) < range;
        //return (Math.Abs(dot) < range);
    }
}
