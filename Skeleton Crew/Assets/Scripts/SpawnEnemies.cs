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

        while (enemies.Count < maxEnemies)
        {
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.GetComponent<Enemy>().target = player;
            enemies.Add(newEnemy);
            /*newEnemy.transform.position = new Vector3(Random.Range(player.transform.position.x-worldWidth/2, player.transform.position.x + worldWidth/2),
                                                      Random.Range(player.transform.position.y - worldHeight/2, player.transform.position.y + worldHeight/2), 0);*/

            newEnemy.transform.position = GetSpawnPosition(worldWidth,worldHeight,player.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private Vector3 GetSpawnPosition(float wW, float wH, Vector3 playerPos)
    {
        bool left = Random.value < 0.5f;
        bool up = Random.value < 0.5f;
        float xPos = wW / 2 + Random.Range(0, wW / 2);
        float yPos = wH / 2 + Random.Range(0, wH / 2);
        if (up) { yPos = playerPos.y + yPos; }
        else { yPos = playerPos.y - yPos; }

        if (left) { xPos = playerPos.x + xPos; }
        else { xPos = playerPos.y - xPos; }

        return new Vector3(xPos, yPos, 0);
    }
}
