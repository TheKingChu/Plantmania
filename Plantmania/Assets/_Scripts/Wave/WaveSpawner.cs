using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public int currentWave;
    private int waveValue;

    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform spawnlocation;
    //determines overall lenght of the waves
    public int waveDuration;
    private float waveTimer;
    //for controlling when enemies spawn during the wave
    private float spawnInterval;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
    }

    private void FixedUpdate()
    {
        //spawn enemy if its less than 0
        if (spawnTimer <= 0) 
        {
            if(enemiesToSpawn.Count > 0)
            {
                //instantiate the first enemy in the list
                Instantiate(enemiesToSpawn[0], spawnlocation.position, Quaternion.identity);
                //after being instantiated remove from the list
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            //end the wave
            else 
            { 
                waveTimer = 0; 
            }
        }
        //reduce the spawn timer and wave timer
        else 
        { 
            spawnTimer -= Time.fixedDeltaTime; 
            waveTimer -= Time.fixedDeltaTime;
        }

    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();

        //this gives a fixed amount of time between each enemy
        spawnInterval = waveDuration / enemiesToSpawn.Count;
        //wave duration is read only
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while(waveValue > 0)
        {
            int randomEnemyID = Random.Range(0, enemies.Count);
            int randomEnemyCost = enemies[randomEnemyID].cost;

            if(waveValue - randomEnemyCost >= 0) 
            {
                generatedEnemies.Add(enemies[randomEnemyID].enemyPrefab);
                waveValue -= randomEnemyCost;
            }
            else if(waveValue <= 0)
            {
                break;
            }
        }

        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
