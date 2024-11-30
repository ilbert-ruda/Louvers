using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float move;
    public float moveSpeed = 6f;

    [SerializeField] private bool jumping;
    [SerializeField] private float jumpSpeed = 1.0f;

    [SerializeField] private float ghostJumpf;

    [SerializeField] private bool isGrounded;
    public Transform feetPosition;
    public float sizeRadius;
    public LayerMask whatIsGround;

    [SerializeField] private bool attackboll;


    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animationPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>(); 
        animationPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //reconhecer chão
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, sizeRadius, whatIsGround);

        // movimentação do personagem

        move = Input.GetAxis("Horizontal");

        // input do pulo do personagem
        if (Input.GetButtonDown("Jump") && ghostJumpf > 0 )
        {
            jumping = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            attackboll = true;  

            if (isGrounded)
            {
                animationPlayer.SetBool("attackGround", true);
                animationPlayer.SetBool("attackJump", false);
            }
            else
            {
                animationPlayer.SetBool("attackGround", false);
                animationPlayer.SetBool("attackJump", true);
            }
        }
        else
        {
            attackboll = false;

            if (isGrounded)
            {
                animationPlayer.SetBool("attackGround", false);
                animationPlayer.SetBool("attackJump", false);
            }
            else
            {
                animationPlayer.SetBool("attackGround", false);
                animationPlayer.SetBool("attackJump", false);
            }
        }

        if (attackboll == false && isGrounded)
        {
            animationPlayer.SetBool("walking", true);
        }
       
        //inverter posição do personagem
            if (move < 0)
        {
            sprite.flipX = true;
        }
        else if(move > 0)
        {
            sprite.flipX = false;
        }

        if (isGrounded)
        {
            ghostJumpf = 0.1f;

            animationPlayer.SetBool("jump", false);
            animationPlayer.SetBool("fall", false);
            animationPlayer.SetBool("jumph", false);
            animationPlayer.SetBool("fallH", false);

            if (rb.velocity.x != 0 && move != 0)
            {
                animationPlayer.SetBool("walking", true);
            }
            else
            {
                animationPlayer.SetBool("walking", false);
            }
        }
        else
        {
            ghostJumpf -= Time.deltaTime;

            if (ghostJumpf <= 0)
            {
                ghostJumpf =  0;
            }

            if (rb.velocity.x == 0)
            {
                animationPlayer.SetBool("walking", false);

                if (rb.velocity.y > 0)
                {                   
                    animationPlayer.SetBool("fall", false);
                    animationPlayer.SetBool("jumph", false);
                    animationPlayer.SetBool("fallH", false);
                    animationPlayer.SetBool("jump", true);                
                }
                if (rb.velocity.y < 0)
                {
                    animationPlayer.SetBool("jump", false);                   
                    animationPlayer.SetBool("jumph", false);
                    animationPlayer.SetBool("fallH", false);
                    animationPlayer.SetBool("fall", true);         
                }
            }
            else
            {
                if (rb.velocity.y > 0)
                {
                    animationPlayer.SetBool("jump", false);
                    animationPlayer.SetBool("fall", false);
                    animationPlayer.SetBool("fallH", false);           
                    animationPlayer.SetBool("jumph", true);                       
                }

                if (rb.velocity.y < 0)
                {
                    animationPlayer.SetBool("jump", false);
                    animationPlayer.SetBool("fall", false);
                    animationPlayer.SetBool("jumph", false);
                    animationPlayer.SetBool("fallH", true);
                }
            }
        }
        //animação do personagem
        if(move != 0)
        {
            animationPlayer.SetBool("walking",true);
        }
        else if (move == 0)
        {
            animationPlayer.SetBool("walking", false); ;
        }
    }

    void FixedUpdate()
    {
        //movimento personagem
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        //pulo personagem
        if(jumping)
        {
            rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);

            jumping = false;
        }
    }

    void EndAnimationATK()
    {
        animationPlayer.SetBool("attackGround", false);
        animationPlayer.SetBool("attackJump", false);

        attackboll = false;
    }
}
