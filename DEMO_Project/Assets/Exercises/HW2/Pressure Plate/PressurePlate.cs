using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] Transform gate;
    [SerializeField] float openSpeed;
    private bool gateOpening;
    private int gateMax = 3;
    private Transform gateOrigPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gateOpening = false;
        gateOrigPos = gate;
    }

    // Update is called once per frame
    void Update()
    {
        if (gateOpening)
        {
            if (gate.position.y < (gateOrigPos.position.y + gateMax))
            {
                gate.position = new Vector3(gateOrigPos.position.x, gateOrigPos.position.y + openSpeed * Time.deltaTime, gateOrigPos.position.z);
            }
            if (gate.position.y > (gateOrigPos.position.y + gateMax))
            {
                gate.position = new Vector3(gateOrigPos.position.x, (gateOrigPos.position.y + gateMax), gateOrigPos.position.z);
            }
        }
        else
        {
            if (gate.position.y > (gateOrigPos.position.y))
            {
                gate.position = new Vector3(gateOrigPos.position.x, gateOrigPos.position.y - openSpeed * Time.deltaTime, gateOrigPos.position.z);
            }
            if (gate.position.y < (gateOrigPos.position.y + gateMax))
            {
                gate.position = gateOrigPos.position;
            }
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
