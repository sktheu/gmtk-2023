using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHorizontalMovement : MonoBehaviour
{
    [Header("Configurações:")]
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxMoveSpeed;

    // Components
    private Rigidbody2D _rb;
    private SpriteRenderer _spr;
    private ObstacleFade _obstacleFade;

    // Movement
    [HideInInspector] public float MoveDir = 1f;
    private float _moveSpeed;

    // Fade
    private bool _canVerifyFade = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spr = GetComponent<SpriteRenderer>();
        _obstacleFade = GetComponent<ObstacleFade>();

        _moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        Invoke("EnableVerifyFade", 2f);

        if (MoveDir == -1f)
            _spr.flipX = true;
    }

    private void FixedUpdate() => ApplyHorizontalMove();

    private void OnTriggerStay2D(Collider2D col)
    {
        if (_canVerifyFade && col.gameObject.tag.Contains("Trigger"))
        {
            _obstacleFade.CanFade = true;
            _rb.velocity = Vector2.zero;
        }
    }

    private void ApplyHorizontalMove() => _rb.velocity = new Vector2(MoveDir * _moveSpeed, 0f);

    private void EnableVerifyFade() => _canVerifyFade = true;
}
