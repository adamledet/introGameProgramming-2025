using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTaget : MonoBehaviour
{
    [SerializeField] Transform current;
    [SerializeField] Transform point1, point2;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        current = point1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, current.position) > 2f)
        {
            transform.position += (current.position - transform.position).normalized * Time.deltaTime * speed; ;
        }
        else
        {
            if (current == point1)
                current = point2;
            else
                current = point1;
        }
    }
}
