using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class MoveV2 : MonoBehaviour,IQuanliLuutru
{
    public static Player Instance { get; private set; }
    [Header("------ Hiệu ứng âm thanh ------")]
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private AudioSource attackSFX;
    [SerializeField] private AudioSource runSFX;
    [Header("------ Di chuyển ------")]
    [SerializeField] float MoveInput;
    [SerializeField] public float moveSpeed = 10;
    [SerializeField] bool isFacingRight = false;
    [SerializeField] public float jumpPower = 25;

    [Header("------ Có đứng trên mặt đất? ------")]
    [SerializeField] bool isGrounded = true;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] private bool Check;
    [SerializeField] public Transform feetPosition;
    [SerializeField] public float groundCheckCircle;

    Rigidbody2D rb;
    Camera cam;
    Animator animator;
    //Animation
    private bool isWalking;
    public bool canMove = true;
    public bool canAttack = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GetComponent<Camera>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {

            Attack();
            Movement();
            Jump();
            FlipSprite();

            MoveInput = Input.GetAxis("Horizontal");    
    }


    private void FixedUpdate()
    {

    }

    void Movement()
    {
        if (canMove == true)
        {
            rb.velocity = new Vector2(MoveInput * moveSpeed, rb.velocity.y);
            if (MoveInput != rb.velocity.x && isGrounded == true)
            {
                runSFX.Play();

            }
            if (rb.velocity.x != 0)
            {
                //animator.SetFloat("X", Mathf.Abs(rb.velocity.x));
                if (!isWalking)
                {
                    isWalking = true;
                    animator.SetBool("isMoving", isWalking);
                }
            }
            else
            {
                if (isWalking)
                {
                    isWalking = false;
                    animator.SetBool("isMoving", isWalking);
                    //StopMoving();
                }
            }

            if (Check == true)
            {
                animator.SetFloat("X", Mathf.Abs(rb.velocity.x));
            }
        }
    }
    void FlipSprite()
    {
        if (Mathf.Abs(rb.velocity.x) > 0)
        {
            float direction = Mathf.Sign(rb.velocity.x);
            transform.localScale = new Vector3(direction, 1, 1);
        }
        /*  if (isFacingRight && MoveInput > 0 || !isFacingRight && MoveInput < 0)
          {
              isFacingRight = !isFacingRight;
               Vector3 ls = transform.localScale;
              ls.x *= -1f;
              transform.localScale = ls;
          } */
    }

    void Jump()
    {
        Check = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded && Check == true)
        {
            jumpSFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
            Debug.Log("Nhay!");
        }
        else
        {
            animator.SetFloat("Y", rb.velocity.y);
        }

    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && Check == true && canAttack == true || Input.GetKeyDown(KeyCode.J) && Check == true && canAttack == true)
        {
            attackSFX.Play();
            animator.SetTrigger("ATK");
            Debug.Log("Tan Cong!");
        }
    }

    void LockMove()
    {
        canMove = false;
    }
    void LockAttack()
    {
        canAttack = false;
    }
    void UnlockAttack()
    {
        canAttack = true;
    }

    void UnlockMove()
    {
        canMove = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isWalking = false;
        isGrounded = true;
        animator.SetBool("isMoving", isWalking);
        animator.SetBool("isJumping", !isGrounded);
    }
    public void LoadData(GameData data)
    {
        this.transform.position = data.targetPosition;
    }
    public void SaveData(GameData data)
    {
        data.targetPosition = this.transform.position;
    }

}
