using System.Collections.Generic;
using UnityEngine;

public class MakeNoise : MonoBehaviour
{
    [SerializeField] float radius = 2f;
    List<MotionSensor> alerted = new();

    // Update is called once per frame
    void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, 2f);
        foreach(var collider in colliders)
        {
            if(collider.TryGetComponent<MotionSensor>(out MotionSensor sensor))
            {
                if(!alerted.Contains(sensor))
                {
                    alerted.Add(sensor);
                    sensor.Alert();
                }
            }
        }
    }
}
