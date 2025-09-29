using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemyPrefab;
    List<GameObject> enemies = new List<GameObject>();
    [SerializeField] int maxEnemies;
    float worldWidth;
    float worldHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float aspect = (float)Screen.width / Screen.height;
        worldHeight = Camera.main.orthographicSize * 2;
        worldWidth = worldHeight * aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count < maxEnemies)
        {
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.GetComponent<Enemy>().target = player;
            enemies.Add(newEnemy);
            newEnemy.transform.position = new Vector3(Random.Range(player.transform.position.x-worldWidth/2, player.transform.position.x + worldWidth/2),
                                                      Random.Range(player.transform.position.y - worldHeight/2, player.transform.position.y + worldHeight/2), 0);
        }
    }
}
