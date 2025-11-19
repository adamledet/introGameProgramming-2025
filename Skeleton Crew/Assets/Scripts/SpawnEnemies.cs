using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    //Player Parameters
    [SerializeField] GameObject player;
    private PlayerStats playerStats;

    //Enemy Parameters
    [SerializeField] GameObject enemyPrefab;
    List<GameObject> enemies = new List<GameObject>();
    [SerializeField] int maxEnemies;

    //Elite Parameters
    [SerializeField] GameObject elitePrefab;
    List<GameObject> elites = new List<GameObject>();
    [SerializeField] int maxElites;

    //World Coords
    float worldWidth;
    float worldHeight;

    // Enemy Timer
    [SerializeField] TextMeshProUGUI enemyTimer;
    private float enemyTimerLeft;
    [SerializeField] float enemyTimerMax;
    private int enemyPowerLevel;
    private float secondsLeft;
    private string secondZero;
    private float minutesLeft;
    private string minuteZero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float aspect = (float)Screen.width / Screen.height;
        worldHeight = Camera.main.orthographicSize * 2;
        worldWidth = worldHeight * aspect;

        playerStats = player.GetComponent<PlayerStats>();

        enemyTimerLeft = enemyTimerMax;
        minuteZero = "";
        secondZero = "";

        RepopulateEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimerLeft -= Time.deltaTime;
        secondsLeft = Mathf.Round(enemyTimerLeft % 60);
        if(secondsLeft < 10) { secondZero = "0"; } else { secondZero = ""; }
        minutesLeft = Mathf.Floor(enemyTimerLeft / 60);
        if (minutesLeft < 10) { minuteZero = "0"; } else { minuteZero = ""; }
        enemyTimer.text = ($"{minuteZero}{minutesLeft}:{minuteZero}{secondsLeft}");
        if (enemyTimerLeft <= 0) { IncreaseEnemyPower(); }
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

    public void IncreaseEnemyPower()
    {
        enemyPowerLevel += 1;
        enemyTimerMax *= 1.1f;
        enemyTimerLeft = enemyTimerMax;
        maxEnemies += (maxEnemies / 3);
        maxElites += 1;
        RepopulateEnemies();
    }

    public void RespawnEnemy(GameObject enemy, Enemy enemyScript)
    {
        enemy.transform.position = GetSpawnPosition(worldWidth, worldHeight, player.transform.position);
    }

    private void RepopulateEnemies()
    {
        while (enemies.Count < maxEnemies)
        {
            var newEnemy = Instantiate(enemyPrefab);
            var enemyScript = newEnemy.GetComponent<Enemy>();
            enemyScript.target = player;
            enemies.Add(newEnemy);
            /*newEnemy.transform.position = new Vector3(Random.Range(player.transform.position.x-worldWidth/2, player.transform.position.x + worldWidth/2),
                                                      Random.Range(player.transform.position.y - worldHeight/2, player.transform.position.y + worldHeight/2), 0);*/

            newEnemy.transform.position = GetSpawnPosition(worldWidth, worldHeight, player.transform.position);
            enemyScript.enemyManagerScript = this;
        }

        while (elites.Count < maxElites)
        {
            var newElite = Instantiate(elitePrefab);
            var eliteScript = newElite.GetComponent<Enemy>();
            eliteScript.target = player;
            elites.Add(newElite);
            /*newEnemy.transform.position = new Vector3(Random.Range(player.transform.position.x-worldWidth/2, player.transform.position.x + worldWidth/2),
                                                      Random.Range(player.transform.position.y - worldHeight/2, player.transform.position.y + worldHeight/2), 0);*/

            newElite.transform.position = GetSpawnPosition(worldWidth, worldHeight, player.transform.position);
            eliteScript.enemyManagerScript = this;
        }
    }
}
