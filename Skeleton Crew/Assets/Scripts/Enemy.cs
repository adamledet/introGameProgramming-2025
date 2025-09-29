using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float speed;
    private Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
