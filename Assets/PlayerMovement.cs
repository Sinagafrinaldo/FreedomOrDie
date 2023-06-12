using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Rb;
    public float ms = 5;
    public float jf = 800;
    private bool isJumping = false;
    private int lastDirection = 1;

    public SpriteRenderer SpriteRenderer;
    public Sprite Standing;
    public Sprite Crouching;
    public BoxCollider2D Collider;
    public Vector2 Standingsize;
    public Vector2 Crouchingsize;

    Animator myAnimator;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();

        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Standing;

        Standingsize = Collider.size;
    }

    void Update()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        Rb.velocity = new Vector2(ms * horiz, Rb.velocity.y);

        if (horiz > 0)
        {
            myAnimator.SetBool("isRunning", true);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            lastDirection = 1;
        }
        else if (horiz < 0)
        {
            myAnimator.SetBool("isRunning", true);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            lastDirection = -1;
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            Rb.AddForce(new Vector2(0, jf));
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.C) && horiz == 0) // Tombol C sedang ditekan
        {
            myAnimator.SetBool("isCrouch", true);
            Collider.size = Crouchingsize;
        }
        else // Tombol C tidak sedang ditekan
        {
            myAnimator.SetBool("isCrouch", false);
            Collider.size = Standingsize;
        }

        if (Rb.velocity.x == 0)
        {
            if (lastDirection == 1)
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            else if (lastDirection == -1)
                transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
