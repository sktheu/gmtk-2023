using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTopDownMovement : MonoBehaviour
{
    [Header("Configurações:")]
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float minChaseTime;
    [SerializeField] private float maxChaseTime;

    // Components
    private Rigidbody2D _rb;
    private SpriteRenderer _spr;
    private ObstacleFade _obstacleFade;

    // Movement
    private Vector2 _moveDir;
    private float _moveSpeed;

    private static Transform _playerTransform;

    private bool _canMove = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spr = GetComponent<SpriteRenderer>();
        _obstacleFade = GetComponent<ObstacleFade>();

        _moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(EnableVerifyFade(Random.Range(minChaseTime, maxChaseTime)));
    }

    private void Update() => SetMoveDir();
    
    private void FixedUpdate() => ApplyTopDownMove();

    private void ApplyTopDownMove()
    {
        if  (_canMove && Random.Range(0, 100) < 20)
            _rb.velocity = _moveDir * _moveSpeed;
    }

    private void SetMoveDir()
    {
        var dx = Mathf.Sign(_playerTransform.position.x - transform.position.x);
        var dy = Mathf.Sign(_playerTransform.position.y - transform.position.y);
        _moveDir = new Vector2(dx, dy).normalized;

        if (dx == -1f)
            _spr.flipX = true;
        else if (dx == 1f)
            _spr.flipX = false;
    }

    private IEnumerator EnableVerifyFade(float t)
    {
        yield return new WaitForSeconds(t);
        _obstacleFade.CanFade = true;
        _canMove = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}