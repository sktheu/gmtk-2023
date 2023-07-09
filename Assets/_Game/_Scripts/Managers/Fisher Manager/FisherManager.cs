using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherManager : MonoBehaviour
{
    [Header("Configurações:")]
    [SerializeReference] private Transform[] spawnPoints;
    public Transform[] movePoints;
    [SerializeField] private FisherMovement[] fisherPrefabs;
    

    public static FisherManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Invoke("SpawnFisher", 2f);
    }

    public void SpawnFisher()
    {
        var spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        Instantiate(fisherPrefabs[Random.Range(0, fisherPrefabs.Length)], spawnPosition, Quaternion.identity);
    }
}
