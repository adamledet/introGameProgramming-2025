using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    [SerializeField] Transform spawnLocation;
    [SerializeField] int limit, current_count;
    [SerializeField] Queue<GameObject> queue = new Queue<GameObject>();

    public void Spawn()
    {
        if (current_count < limit)
        {
            current_count++;
        }
        else
        {
            var first = queue.Dequeue();
            Destroy(first);
        }
        var obj = Instantiate(sphere);
        queue.Enqueue(obj);
    }
}
