using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] Transform gate;
    [SerializeField] float openSpeed;
    [SerializeField] int gateRaise;//Amount gate can be raised
    private bool gateOpening;
    private Vector3 gateOrig;//Gate's starting position
    private Vector3 gateMax;//Gate's 'raised' position

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gateOpening = false;
        gateOrig = gate.position;

        gateMax = gateOrig;
        gateMax.y += gateRaise;
    }

    // Update is called once per frame
    void Update()
    {
        if (gateOpening)
        {
            //Debug.Log($"RISE: Current: {gate.position}, Target: {gateMax}");
            gate.position = Vector3.Lerp(gate.position, gateMax, Time.deltaTime * openSpeed);
        }
        else
        {
            //Debug.Log($"FALL: Current: {gate.position}, Target: {gateOrig}");
            gate.position = Vector3.Lerp(gate.position, gateOrig, Time.deltaTime * openSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        gateOpening = true;
    }
    void OnTriggerExit(Collider other)
    {
        gateOpening = false;
    }
}
