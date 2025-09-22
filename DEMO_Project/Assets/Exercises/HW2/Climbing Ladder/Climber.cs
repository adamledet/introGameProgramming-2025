using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class Climber : MonoBehaviour
{
    [SerializeField] ThirdPersonController controller;
    [SerializeField] StarterAssetsInputs inputManager;
    [SerializeField] bool _climbing;
    bool climbing
    {
        get => _climbing;
        set
        {
            _climbing = value;
            controller.enabled = !value;
        }
    }

    private void OnValidate()
    {
        inputManager = GetComponent<StarterAssetsInputs>();
        controller = GetComponent<ThirdPersonController>();// Only access Serialized things
    }

    private void Update()
    {
        if (climbing)
        {
            var input = inputManager.move;
            var input3D = new Vector3(0, input.y, 0);
            transform.position += input3D * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Toggle(other, true);
    }

    private void Toggle(Collider other, bool on)
    {
        var ladder = other.GetComponent<Ladder>();
        if (ladder)
        {
            climbing = on;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Toggle(other, false);
    }
}
