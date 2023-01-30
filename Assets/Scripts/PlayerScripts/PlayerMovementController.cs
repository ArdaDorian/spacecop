using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D m_rb;

    Vector2 minBound;
    Vector2 maxBound;

    [SerializeField] float horizontalSpeed, verticalSpeed;
    [SerializeField] float paddingLeft, paddingRight, paddingBottom;

    Shooter shooter;

    private void Awake()
    {
        shooter= GetComponent<Shooter>();
        m_rb= GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        InitBounds();
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, .5f));
    }

    private void Update()
    {
        LimitMovement();
    }

    private void LimitMovement()
    {
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x,minBound.x+paddingLeft, maxBound.x-paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y,minBound.y+paddingBottom, maxBound.y);
        transform.position = newPos;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 movementVelocity = new Vector2(moveInput.x*horizontalSpeed, moveInput.y*verticalSpeed);
        m_rb.velocity = movementVelocity;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
