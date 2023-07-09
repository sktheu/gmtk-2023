using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSpawner : MonoBehaviour
{
    [Header("Configurações:")] 
    [SerializeField] private GameObject objectivePrefab;
    [SerializeField] private Transform[] objectiveSpawnPoints;


    [HideInInspector] public bool Spawned = false;

    [HideInInspector] public GameObject ObjectiveObj;

    private LineRenderer _lineRenderer;

    private Vector3 _objectiveSpawnPos;

    private void Start() => _lineRenderer = GetComponent<LineRenderer>();

    public void Spawn()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        if (GetComponent<SpriteRenderer>().flipX)
            _objectiveSpawnPos = objectiveSpawnPoints[1].position;
        else
            _objectiveSpawnPos = objectiveSpawnPoints[0].position;

        var obj = Instantiate(objectivePrefab, _objectiveSpawnPos, Quaternion.identity);
        obj.GetComponent<ObjectiveMovement>().FisherObj = GetComponent<FisherMovement>();
        ObjectiveObj = obj;

        _lineRenderer.enabled = true;
    }

    private void Update()
    {
        if (_lineRenderer.enabled)
        {
            _lineRenderer.SetPosition(0, _objectiveSpawnPos);
            _lineRenderer.SetPosition(1, ObjectiveObj.transform.position);
        }
    }
}
