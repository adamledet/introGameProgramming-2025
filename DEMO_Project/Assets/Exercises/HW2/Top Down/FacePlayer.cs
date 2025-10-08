using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    [SerializeField] Transform player;

    // Update is called once per frame
    void Update()
    {
        //transform.forward
        transform.forward = (player.position - transform.position);

        // transform.LookAt
        //transform.LookAt(player.position);

        //transform.euler
        //var angle = Vector3.Angle(transform.forward, (player.position - transform.position));//This is the difference of degrees between current forward and vector between this and the target (player).
        /*if(angle > 1)//only apply when there is a certain degree of difference
            transform.eulerAngles += new Vector3(0, angle, 0);*/

        //quaternion euler
        //var rotation = Quaternion.Euler(0, angle, 0);
        //transform.rotation = rotation;

        //quaternion.LookRotation
        //transform.rotation = Quaternion.LookRotation(player.position - transform.position);

        //quaternion.RotateTowards
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime);//Rotate 1 degree every second

        //quaternion.lerp

        //quaternion.slerp
    }
}
