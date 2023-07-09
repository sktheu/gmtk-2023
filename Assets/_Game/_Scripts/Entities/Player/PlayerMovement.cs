using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Unity Access Fields
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float turnScalar;

    // Components
    private Rigidbody2D _rb;
    private SpriteRenderer _spr;
    private Animator _anim;

    // Movement
    private Vector2 _moveInput;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GetMoveInput();
        FlipSprite();

        _anim.SetFloat("move", Mathf.Abs(_rb.velocity.x));
    }

    private void FixedUpdate() => ApplyMove();

    private void GetMoveInput() => _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

    private Vector2 SetVelocity(Vector2 goal, Vector2 curVel, float accel)
    {
        var move = Vector2.zero;

        var velDifferenceX = goal.x - curVel.x;
        var velDifferenceY = goal.y - curVel.y;

        if (velDifferenceX > accel) move.x = curVel.x + accel;
        else if (velDifferenceX < -accel) move.x = curVel.x - accel;
        else move.x = goal.x;

        if (velDifferenceY > accel) move.y = curVel.y + accel;
        else if (velDifferenceY < -accel) move.y = curVel.y - accel;
        else move.y = goal.y;

        return move;
    }

    private void ApplyMove() => _rb.velocity = SetVelocity(maxSpeed * _moveInput, _rb.velocity, acceleration);

    private void FlipSprite()
    {
        if (_moveInput.x < 0f) _spr.flipX = true;
        else if (_moveInput.x > 0f) _spr.flipX = false;
    }
}
