using UnityEngine;

public class LockOn : MonoBehaviour
{
    [SerializeField] bool LockedOn;
    [SerializeField] Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target.position);
        //transform.forward = (target.position - transform.position);

        
        /*var angle = Vector3.Angle(transform.forward, (target.position - transform.position));
        var rotation = Quaternion.Euler(0, angle, 0);
        var b = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, b, Time.deltaTime);*/
    }

    void OnLockOn()
    {

    }
}
