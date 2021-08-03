using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemy;
    public Wave[] waves;
    public float timeBetweenWaves;
    
    private Wave _curWave;
    private int _curWaveNumber;
    
    private int _enemiesToSpawn;
    private int _enemiesAlive;
    private float _nextSpawnTime;

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        if (_enemiesToSpawn > 0 && Time.time > _nextSpawnTime)
        {
            _enemiesToSpawn--;
            _nextSpawnTime = Time.time + _curWave.timeBetweenSpawns;
            
            Enemy spawnedEnemy = Instantiate(enemy,Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath()
    {
        _enemiesAlive--;
        if (_enemiesAlive == 0)
        {
            NextWave();
        }
    }
    void NextWave()
    {
        _curWaveNumber++; 
        print("Wave " + _curWaveNumber);
        if (_curWaveNumber - 1 < waves.Length)
        {
            _curWave = waves[_curWaveNumber - 1];
            _enemiesToSpawn = _curWave.enemyCount;
            _enemiesAlive = _enemiesToSpawn;
        }
    }
    [System.Serializable]
   public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
