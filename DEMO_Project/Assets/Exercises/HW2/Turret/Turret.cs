using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform gun;
    [SerializeField] Transform target;
    [SerializeField] float time, cooldown;
    //Queue<Bullet> pool = new();

    /*void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            pool.Enqueue(bullet);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > cooldown)
        {
            time = 0;
            Shoot();
        }
        transform.forward = target.position - transform.position;
    }

    private void Shoot()
    {
        /*if (pool.Count > 0)
        {
            var bullet = pool.Dequeue();
            bullet.gameObject.SetActive(true);
            bullet.transform.position = gun.position;
            bullet.transform.rotation = gun.rotation;
        }*/
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = gun.position;
        bullet.transform.rotation = gun.rotation;
    }
}
