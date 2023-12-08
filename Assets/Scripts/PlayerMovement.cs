using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float moveSpeed = 5f;
    private Vector2 moveDirection = Vector2.zero; //Atajo de (X:0;Y:0)
    private PlayerInputActions playerControls;
    public bool meleeEquiped = true;
    private SpriteRenderer spriteRenderer;
    private Animator playerAnimator;
    
    public void PlayerIsMeleeEquip(bool meleeEquiped) {
        this.meleeEquiped = meleeEquiped;
    }
    
    public UnityEvent PlayerShootingEvent;
    public UnityEvent PlayerMeleeEvent;
    public UnityEvent PlayerWateringEvent;
    public UnityEvent PlayerInteracEvent;
    public UnityEvent PlayerNextItemEvent;
    public UnityEvent PlayerPreviusItemEvent;
    public UnityEvent PlayerTimeJump;
    private bool canDash = true;
    private bool playerCollision;
    [SerializeField] private float DashTime=0.5f;
    [SerializeField] private Transform targetToRotateFoward;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
    }

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    IEnumerator Dash() {
        playerCollision = false;
        if (canDash) {
            moveSpeed = moveSpeed * 2;
            canDash = false;
            playerCollision = false;
            yield return new WaitForSeconds(DashTime);
            canDash = true;
            moveSpeed = moveSpeed / 2;
            playerCollision = true;
        }
    }


    private void OnEnable()
    {
        playerControls.Player.Move.Enable();
        playerControls.Player.Shoot.Enable();

        playerControls.Player.Dash.Enable();
        playerControls.Player.Water.Enable();
        playerControls.Player.Interaction.Enable();
        playerControls.Player.TimeJump.Enable();
        playerControls.Player.Pause.Enable();
        playerControls.Player.Aim.Enable();
        playerControls.Player.PreviousItem.Enable();
        playerControls.Player.NextItem.Enable();
        playerControls.Player.ChangeWeapon.Enable();

        playerControls.Player.Shoot.performed += OnShoot;
        playerControls.Player.Water.performed += OnWatering;
       playerControls.Player.Dash.performed += Dashing;
       playerControls.Player.Interaction.performed += Interacting;
       playerControls.Player.PreviousItem.performed += OnNextItem;
       playerControls.Player.NextItem.performed += OnPreviusItem;
       playerControls.Player.ChangeWeapon.performed += OnChangeWeaponType;
       playerControls.Player.TimeJump.performed += OnTimeJump;
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
        Vector2 currentPosition = transform.position*Time.deltaTime;
    }
    private void Flip()
    {
        spriteRenderer.flipX = moveDirection.x < 0; //se podria implementar la rotación del sprite del PJ
    }
    private void OnShoot(InputAction.CallbackContext context)
    {
        if (meleeEquiped) {
            PlayerMeleeEvent.Invoke();
        } else {
        PlayerShootingEvent.Invoke();
        }
    }
    private void OnChangeWeaponType(InputAction.CallbackContext context) {
   
           meleeEquiped = !meleeEquiped;
        
    }
    private void OnWatering(InputAction.CallbackContext context) {
        PlayerWateringEvent.Invoke();
    }
    private void OnPreviusItem(InputAction.CallbackContext context) {
        PlayerPreviusItemEvent.Invoke();
    }
    private void OnNextItem(InputAction.CallbackContext context) {
        PlayerNextItemEvent.Invoke();
    }
    private void Dashing(InputAction.CallbackContext context) {
        StartCoroutine(Dash());
    }
    private void OnTimeJump(InputAction.CallbackContext context) {
        print("timejump call");
        PlayerTimeJump.Invoke();
    }
    private void Interacting(InputAction.CallbackContext context) {
        
        PlayerInteracEvent.Invoke();    
       // print("interacted");

    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        //Aim Mouse
        // Obtiene la posición del mouse

        // Obtiene la posición del mouse en la pantalla
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Convierte la posición del mouse en la pantalla en una posición en el mundo del juego
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.z));

        // Calcula la dirección entre el objeto y el mouse
        Vector3 direction = worldPosition - transform.position;

        // Calcula el ángulo entre la dirección y el eje X
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica la rotación al objeto
        targetToRotateFoward.rotation = Quaternion.Euler(0f, 0f, angle);
        
        //Animation

        if (playerAnimator)
        {
            playerAnimator.SetFloat("Horizontal", moveX);
            playerAnimator.SetFloat("Vertical", moveY);
            playerAnimator.SetFloat("Speed", moveDirection.sqrMagnitude);
            
        }
        
        moveDirection = new Vector2(moveX, moveY);
    }
}