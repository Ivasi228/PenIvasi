using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 0.001f;
    [SerializeField] private int lives = 2;
    [SerializeField] private float jumpForce = 15f;
    private bool isGrounded = false;


    private Rigidbody2D rb;
    public Animator anim;
    private SpriteRenderer sprite;

    public static Hero Instance { get; set; }


    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }


    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>(); 
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (isGrounded) State = States.Idle;

        rb.velocity = Vector2.zero;
        
        if (Input.GetButton("Horizontal"))
            Walk();
        
        CheckGround();

        
    }

    private void Update()
    {
        rb.WakeUp();
        
        
        if (isGrounded && Input.GetButtonDown("Jump"))
        Jump();
    }

    private void Walk()
    {
        if (isGrounded) State = States.Walk;

        int d = 0;

        if (Input.GetKey(KeyCode.A)) d = -1;

        if (Input.GetKey(KeyCode.D)) d = 1;

        Vector3 dir = transform.right * d;

        //transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        //rb.AddForce(dir * speed * Time.deltaTime, ForceMode2D.Impulse);

        rb.velocity = dir * speed;

        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;

    }
    public /*override*/ void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);
    }
}

public enum States
{
    Idle,
    Walk
}