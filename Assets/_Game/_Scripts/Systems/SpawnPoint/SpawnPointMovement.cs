using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointMovement : MonoBehaviour
{
    [Header("Configurações:")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveDir;
    [SerializeField] private SpawnPointMoveType moveType;

    // Components
    private Rigidbody2D _rb;

    private enum SpawnPointMoveType
    {
        Horizontal,
        Vertical
    }

    private void Start() => _rb = GetComponent<Rigidbody2D>();

    private void FixedUpdate() => ApplyMove();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "TriggerFlip")
            moveDir *= -1f;
    }

    private void ApplyMove()
    {
        if (moveType == SpawnPointMoveType.Horizontal)
            _rb.velocity = new Vector2(moveDir * moveSpeed, 0f);
        else
            _rb.velocity = new Vector2(0f, moveDir * moveSpeed);
    }
}
