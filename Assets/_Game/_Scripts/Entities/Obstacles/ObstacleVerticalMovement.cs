using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVerticalMovement : MonoBehaviour
{
    [Header("Configurações:")]
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxMoveSpeed;

    // Components
    private Rigidbody2D _rb;
    private ObstacleFade _obstacleFade;

    // Movement
    private float _moveSpeed;

    // Fade
    private bool _canVerifyFade = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _obstacleFade = GetComponent<ObstacleFade>();

        _moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        if (Random.Range(0, 100) < 50)
            GetComponent<SpriteRenderer>().flipX = true;

        Invoke("EnableVerifyFade", 2f);
    }

    private void FixedUpdate() => ApplyVerticalMove();

    private void OnTriggerStay2D(Collider2D col)
    {
        if (_canVerifyFade && col.gameObject.CompareTag("WallUp"))
        {
            _obstacleFade.CanFade = true;
            _rb.velocity = Vector2.zero;

            Invoke("EnableVerifyFade", 0.01f);
        }
    }

    private void ApplyVerticalMove() => _rb.velocity = Vector2.up * _moveSpeed;

    private void EnableVerifyFade() => _canVerifyFade = true;
}
