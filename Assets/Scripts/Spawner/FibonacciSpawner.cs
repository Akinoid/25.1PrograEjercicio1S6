using System;
using System.Collections.Generic;
using UnityEngine;

public class FibonacciSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private List<int> fibonacci = new List<int> { 1, 1 };
    private int currentIndex = 0;
    private float timer = 0f;
    private float spawnInterval = 5f;
    private void OnEnable()
    {
        EnemyBase.OnAnyEnemyKilled += HandleEnemyKilled;
    }

    private void OnDisable()
    {
        EnemyBase.OnAnyEnemyKilled -= HandleEnemyKilled;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemies();
            AdvanceFibonacciIndex();
        }
    }

    private void HandleEnemyKilled()
    {
        //AdvanceFibonacciIndex();
    }

    private void AdvanceFibonacciIndex()
    {
        currentIndex++;
        if (currentIndex >= fibonacci.Count)
        {
            int next = fibonacci[^1] + fibonacci[^2]; 
            fibonacci.Add(next);
        }
    }

    private void SpawnEnemies()
    {
        int enemiesToSpawn = fibonacci[currentIndex];
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var prefab = enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)];
            var point = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            Instantiate(prefab, point.position, Quaternion.identity);
        }
        Debug.Log($"Spawned {fibonacci[currentIndex]} enemies (Fib Index: {currentIndex})");
    }
}
