using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Configurações Horizontal:")] 
    [SerializeField] private ObstacleHorizontalMovement[] obstacleHPrefabs;
    [SerializeField] private Transform[] spawnPointsH;
    [SerializeField] private float minSpawnTimeH;
    [SerializeField] private float maxSpawnTimeH;

    [Header("Configurações Vertical:")] 
    [SerializeField] private ObstacleVerticalMovement obstacleVPrefab;
    [SerializeField] private Transform spawnPointV;
    [SerializeField] private float minSpawnTimeV;
    [SerializeField] private float maxSpawnTimeV;

    [Header("Configurações Top-Down:")] 
    [SerializeField] private ObstacleTopDownMovement obstacleTDPrefab;
    [SerializeField] private Transform[] spawnPointsTD;
    [SerializeField] private float minSpawnTimeTD;
    [SerializeField] private float maxSpawnTimeTD;

    private void Start()
    {
        StartCoroutine(SpawnObstacleH());
        StartCoroutine(SpawnObstacleV());
        StartCoroutine(SpawnObstacleTD());
    }

    private IEnumerator SpawnObstacleH()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnTimeH, maxSpawnTimeH));
        var index = Random.Range(0, spawnPointsH.Length);

        var obstacleH = Instantiate(obstacleHPrefabs[Random.Range(0, obstacleHPrefabs.Length)], spawnPointsH[index].position, 
            Quaternion.identity);

        if (index == 0)
            obstacleH.MoveDir = 1f;
        else
            obstacleH.MoveDir = -1f;

        StartCoroutine(SpawnObstacleH());
    }

    private IEnumerator SpawnObstacleV()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnTimeV, maxSpawnTimeV));

        Instantiate(obstacleVPrefab, spawnPointV.position, Quaternion.identity);

        StartCoroutine(SpawnObstacleV());
    }

    private IEnumerator SpawnObstacleTD()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnTimeTD, maxSpawnTimeTD));

        Instantiate(obstacleTDPrefab, spawnPointsTD[Random.Range(0, spawnPointsTD.Length)].position,
            Quaternion.identity);

        StartCoroutine(SpawnObstacleTD());
    }
}
