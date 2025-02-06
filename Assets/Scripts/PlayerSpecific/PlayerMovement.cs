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

    private void FixedUpdate()
    {
        moveDir = playerMove.ReadValue<Vector3>();
        rb.velocity = new Vector3((moveDir.x * moveSpeed), moveDir.y, moveDir.z);
    }
}
