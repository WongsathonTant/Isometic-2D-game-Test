using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float EnemySpawnCooldown;
    [SerializeField] private float EnemyDelay;
    [SerializeField] private Transform[] MobSpawnPoints;
    [SerializeField] private Enemy[] Enemys;

    private void Update()
    {
        if(EnemySpawnCooldown <= 0)
        {
            MobSpawn();
        }
        EnemySpawnCooldown -= Time.deltaTime;
    }

    private void MobSpawn()
    {
        EnemySpawnCooldown = EnemyDelay;
        Transform mobSpawnPoint = ChooseMobSpawnPoint();
        Enemy enemyPrefab = ChooseEnemy();
        Enemy enemy = Instantiate(enemyPrefab, mobSpawnPoint.position, mobSpawnPoint.rotation);

    }
    Transform ChooseMobSpawnPoint()
    {
        int randomIndex = UnityEngine.Random.Range(0, MobSpawnPoints.Length);
        var mobSpawnPoint = MobSpawnPoints[randomIndex];
        return mobSpawnPoint;
    }
    Enemy ChooseEnemy()
    {
        int randomIndex = UnityEngine.Random.Range(0, Enemys.Length);
        var enemy = Enemys[randomIndex];
        return enemy;
    }
}
