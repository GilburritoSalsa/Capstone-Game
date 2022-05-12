using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBehavior : MonoBehaviour
{
    int spawnsRemaining;
    //GameObject[] enemyPool;
    public GameObject enemy;
    public GameObject[] spawners;
    float spawnDelay;
    float spawnTimer;
    public GameObject spawner;
    private int enemiesAlive;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnsRemaining = 0;
        spawnTimer = 0;
        spawnDelay = 3;
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        //enemyPool.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // Update time since last frame
        spawnTimer += Time.deltaTime;

        // If the timer has reached the time delay, spawn an enemy and reset the timer.
        if (spawnTimer >= spawnDelay && spawnsRemaining > 0)
        {
            spawnTimer = 0;
            spawn();
        }
    }

    /* For rounds when enemies are added to the pool
    public void onRoundStart(float difficulty, GameObject[] newEnemies)
    {
        // Add to enemy pool based on difficulty mod
        enemyPool.SetValue(BasicEnemy, 0);

        // Set number of spawns per round based on difficulty mod
        spawnsRemaining = 0;

        // Set spawn timer to zero
        spawnTimer = 0;

        // Populate the spawn pool
    }
    */

    // For rounds when no new enemies are added to the pool
    public void onRoundStart(float difficulty)
    {
        // Spawns per round subject to change
        spawnsRemaining = (int)(5 + difficulty);
        spawnTimer = 0;
        enemiesAlive = 0;
    }

    public void onRoundEnd(int wave)
    {

    }

    void spawn()
    {
        // ENEMY POOL MUST BE IMPLEMENTED, CURRENTLY ONLY SPAWNS ONE KIND OF ENEMY
        // Select an index at random to spawn an enemy
        //int spawnIndex = Random.Range(0, enemyPool.Length());

        // Pull random enemy from spawn pool and
        // instantiate the enemy at a spawn point

        // Choose spawner to use
        int index = Random.Range(0, spawners.Length);
        spawner = spawners[index];

        // Spawn enemy at spawn point
        Instantiate(enemy, spawner.transform.position, Quaternion.identity);

        // Update remaining spawns
        spawnsRemaining -= 1;
        enemiesAlive += 1;
        Debug.Log("After spawn, " + enemiesAlive + " currently alive.");
    }

    public bool isEverythingDead() { if (spawnsRemaining == 0 && enemiesAlive == 0) return true; else return false; }
    public void enemyDies() { enemiesAlive = enemiesAlive - 1; Debug.Log(enemiesAlive + " Enemies currently alive"); }
}
