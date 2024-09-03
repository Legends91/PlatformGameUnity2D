using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public float jumpTime = 0.6f;
    public float jumpTimeCounter;
    private bool isJumping;

    private Animator any; // animation
    private bool anyIf;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        any = GetComponent<Animator>(); // animation

    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal");
        if (input < 0)
        {
            spriteRenderer.flipX = true;
            this.Quay_Trai();
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
            this.Quay_Phai();
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded == true && Input.GetButtonDown("Jump")  ) 
        {
           
            isJumping = true;
           
            playerRb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                this.Jump();
                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping= false; 
        }

        if (isJumping == true)
        {
            jumpTimeCounter -= Time.deltaTime;
        }
        else 
        { jumpTimeCounter = jumpTime; }

      
            any.SetFloat("XInput", Mathf.Abs(input)); // animation
            any.SetFloat("YInput", Mathf.Abs(input)); // animation
          
        
      
    }
    void FixedUpdate()
    {
        playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);

    }



    void Jump()
    {
        Debug.Log("Nhay!");
    }
    void Quay_Trai()
    {
        Debug.Log("Quay trai!");
    }
    void Quay_Phai()
    {
        Debug.Log("Quay phai!");
    }

}
