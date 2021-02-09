using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9f;
    public int enemyCount;
    private int waveNumber = 1; //колличество врагов в волне
    

    private void Start()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber); //увеличивающееся колличество врагов
    }

    private void Update()
    {
        
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0) //если количество врагов в сцене равно 0 создать одного врага
        {
            waveNumber++; //увеличение колличества врагов в волне после того как на сцене их остается 0
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }


    private Vector3 GenerateSpawnPosition()
    {        
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);


        //задаем Vector3 со случайными координатами по Х и У
        Vector3 randomSpawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        //вот это после вызова метода подставится вместо метода то есть вернется что одно и то же
        return randomSpawnPos;
    }

    //создаем аргумент для собственной функции в нашем случае колличество создаваемых врагов:
    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        //в цикле for мы создаем указанное в аргументе функции колличество врагов
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        
    }
}
