using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] float speed;
    float t;
    void Update()
    {
        t += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(new Vector3(0, t, 0));
    }
}
