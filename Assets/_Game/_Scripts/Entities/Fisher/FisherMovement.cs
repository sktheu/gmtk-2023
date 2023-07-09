using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherMovement : MonoBehaviour
{
    [Header("Configurações:")] 
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxMoveSpeed;

    // Components
    private SpriteRenderer _spr;
    private ObjectiveSpawner _objectiveSpawner;

    private Vector3 _targetPosition;
    private float _moveSpeed;

    private bool _isLeaving = false;
    private float _leavingDir = 1f;

    private void Start()
    {
        _spr = GetComponent<SpriteRenderer>();
        _moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        _objectiveSpawner = GetComponent<ObjectiveSpawner>();
        SetTargetPosition(FisherManager.Instance.movePoints[0].position, FisherManager.Instance.movePoints[1].position);
    }

    private void Update()
    {
        if (!_isLeaving)
            ApplyMovement();
        else
            Leave();
    } 

    private void SetTargetPosition(Vector3 a, Vector3 b)
    {
        var x = Random.Range(a.x, b.x);
        var y = Random.Range(a.y, b.y);
        _targetPosition = new Vector3(x, y, 1f);

        if (x < transform.position.x)
            _spr.flipX = true;
    }

    private void ApplyMovement()
    {
        if (Vector2.Distance(transform.position, _targetPosition) >= 4f)
        {
            var newPos = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
            transform.position = newPos;
        }
        else if (!_objectiveSpawner.Spawned)
        {
            _objectiveSpawner.Spawn();
            _objectiveSpawner.Spawned = true;
        }
    }

    public void StartLeaving()
    {
        _isLeaving = true;
        if (_spr.flipX)
            _leavingDir *= -1f;

        Destroy(_objectiveSpawner.ObjectiveObj);
        GetComponent<LineRenderer>().enabled = false;

        Destroy(gameObject, 10f);

        FisherManager.Instance.SpawnFisher();

        ScoreManager.Instance.AddScore();

        AudioManager.Instance.PlaySFX("mordida");
    }

    private void Leave() => transform.position += new Vector3(_leavingDir * _moveSpeed * 1.5f * Time.fixedDeltaTime, 0f, 0f);
}
