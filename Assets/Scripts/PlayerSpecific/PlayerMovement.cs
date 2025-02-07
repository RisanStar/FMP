using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerCntrls playerCntrls;
    [SerializeField] private InputAction playerMove;

    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Rigidbody rb;

    [Header("Player Movement")]
    private Vector3 moveDir;
    [SerializeField] private float moveSpeed;

    [SerializeField] private LayerMask ground;

    private void Awake()
    {
        playerCntrls = new PlayerCntrls();
        rb = GetComponentInChildren<Rigidbody>();

    }

    private void OnEnable()
    {
        playerMove = playerCntrls.Player.Walking;
        playerMove.Enable();
    }

    private void OnDisable()
    {
        playerMove.Disable();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        moveDir = playerMove.ReadValue<Vector2>();
        rb.velocity = new Vector2((moveDir.x * moveSpeed), moveDir.y);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position, Vector2.down, .2f, ground);
    }
}
