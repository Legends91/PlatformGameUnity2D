using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class move : NetworkBehaviour
{
    public static move Instance { get; private set; }

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [SerializeField] private float horizontal;
    [SerializeField] private float tocdo = 5f;
    [SerializeField] private float nhay = 16f;
    [SerializeField] private bool xoaynguoi = true;
    [SerializeField] private Vector2 otherPos;

    Vector2 moveDirection = Vector2.zero;
   /* private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    } */

    
    void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        else { 
        rb.velocity = new Vector2(horizontal * tocdo, rb.velocity.y);

            if (!xoaynguoi && horizontal > 0f)
            {
                Xoay();
            }
            else if (xoaynguoi && horizontal < 0f)
            {
                Xoay();
            }
           
        }
    }




    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, nhay);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    // Update is called once per frame
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Xoay()
    {
        xoaynguoi = !xoaynguoi;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
