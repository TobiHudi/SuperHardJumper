using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]public LayerMask floorLayerMask;
    private BoxCollider2D boxcollider2d;
    private Rigidbody2D rigidbody2d;
    public float horizontalInput;
    private bool facingRight;
    private bool rPressed;
    public float speed = 10f;
    public ParticleSystem dust;
    private float cooldownTime = 0.2f;
    private float nextfireTime = 0f;
    public GameObject respawnDontMove;

    /*
    ░▄▀▄▀▀▀▀▄▀▄░░░░░░░░░
    ░█░░░░░░░░▀▄░░░░░░▄░
    █░░▀░░▀░░░░░▀▄▄░░█░█
    █░▄░█▀░▄░░░░░░░▀▀░░█
    █░░▀▀▀▀░░░░░░░░░░░░█
    █░░░░░░░░░░░░░░░░░░█
    █░░░░░░░░░░░░░░░░░░█
    ░█░░▄▄░░▄▄▄▄░░▄▄░░█░
    ░█░▄▀█░▄▀░░█░▄▀█░▄▀░
    ░░▀░░░▀░░░░░▀░░░▀░░░
    */

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        
        rPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > nextfireTime)
        {
            
            float JumpVelocity = 10f;
            if (IsGrounded() && Input.GetKey(KeyCode.Space))
            {
                CreateDust();

                rigidbody2d.velocity = Vector2.up * JumpVelocity;

                SoundManagerScript.Playsound("jump");

                nextfireTime = Time.time + cooldownTime;

            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rPressed = true;
        }
        else
        {
            rPressed = false;
        }

        if (rPressed == true)
        {
            speed = 15f;
        }

        if (rPressed == false)
        {
            speed = 10f;
        }

        //Axis initializer for player flipping
        horizontalInput = Input.GetAxis("Horizontal");
        //Wont let the Player rotate around if it collides with something not Rectengular.
        transform.eulerAngles = Vector3.left * 0;

        if (IsGrounded()) HandleMovement();
        
    }

    //Does a fixed Update that is more Secure but needs more Computer Power (Just recommended if it is a Game without High Graphics like this Game here!)
    private void FixedUpdate()
    {
       if (IsGrounded()) Flip(horizontalInput);
    }
    //flips the character
    private void Flip(float horizontalInput)
    {
        
        if (horizontalInput > 0 && !facingRight || horizontalInput < 0 && facingRight) 
        {
            facingRight = !facingRight;
            Vector3 myScale = transform.localScale;
            myScale.x *= -1;
            transform.localScale = myScale;
        }
    }

    //Handles the left and right movement and makes the Game harder
    private void HandleMovement()
    { 
            if (Input.GetKey(KeyCode.D))
        {
            
            rigidbody2d.velocity = new Vector2(+speed, rigidbody2d.velocity.y);
            
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                
                rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
         
            }
            else
                {
                    rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                    CreateDust();
                }
            }

       

    }

    //initialisation
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxcollider2d = transform.GetComponent<BoxCollider2D>();
    }

    //checks if smth is under feet
    private bool IsGrounded()
    {
        RaycastHit2D rayCastHit2d = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size, 0f, Vector2.down, .1f, floorLayerMask);
        Debug.Log(rayCastHit2d.collider);
        return rayCastHit2d.collider != null;

    }

    public void CreateDust()
    {
        dust.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (respawnDontMove.transform.position == transform.position)
        {
            rigidbody2d.velocity = new Vector2(0, -2);
        }
        
    }

}
