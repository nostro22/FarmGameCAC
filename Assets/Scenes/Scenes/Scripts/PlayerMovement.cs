using System;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float moveSpeed = 5f;
    private Vector2 moveDirection = Vector2.zero; //Atajo de (X:0;Y:0)
    private PlayerInputActions playerControls;
    private SpriteRenderer spriteRenderer;
    private Animator playerAnimator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
    }

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Player.Move.Enable();
        playerControls.Player.Dash.Enable();

        playerControls.Player.Water.Enable();
        playerControls.Player.Interaction.Enable();
        playerControls.Player.TimeJump.Enable();
        playerControls.Player.Pause.Enable();

        playerControls.Player.Shoot.performed += Shoot;
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        _rb.MovePosition(_rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private void Move()
    {
        Vector2 currentPosition = transform.position;
    }
    private void Flip()
    {
        spriteRenderer.flipX = moveDirection.x < 0; //se podria implementar la rotación del sprite del PJ
    }
    private void Shoot(InputAction.CallbackContext context)
    {
        throw new NotImplementedException(); //Implementar método de disparo*
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.T))
            Debug.Log("Avanza el tiempo y se bloquea la funcion al llegar a la noche");


        moveDirection = new Vector2(moveX, moveY);
    }
}