using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSensor : MonoBehaviour
{
    [SerializeField] Material red, green;
    [SerializeField] float cooldown;
    [SerializeField] new MeshRenderer renderer;

    private void OnValidate()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        renderer.material = green;
    }

    public void Alert()
    {
        renderer.material = red;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(2);
        renderer.material = green;
    }
}
