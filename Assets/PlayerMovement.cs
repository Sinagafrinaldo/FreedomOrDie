using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Rb;
    public float ms = 5;
    public float jf = 800;
    private bool isJumping = false;
    private bool isFalling = false; // Menandai apakah karakter sedang jatuh
    private int lastDirection = 1;

    public SpriteRenderer SpriteRenderer;
    public Sprite Standing;
    public Sprite Crouching;
    public BoxCollider2D Collider;
    public Vector2 Standingsize;
    public Vector2 Crouchingsize;

    private bool MoveLeft;
    private bool MoveRight;
    private bool MoveJump;
    private bool MoveCrouch;



    Animator myAnimator;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();

        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Standing;

        Standingsize = Collider.size;
        MoveLeft = false;
        MoveRight = false;
        MoveJump = false;
        MoveCrouch = false;


    }

    public void PointerDownLeft()
    {
        MoveLeft = true;
    }
    public void PointerUpLeft()
    {
        MoveLeft = false;
    }
    public void PointerDownRight()
    {
        MoveRight = true;
    }
    public void PointerUpRight()
    {
        MoveRight = false;
    }

    public void PointerDownJump()
    {
        MoveJump = true;
    }
    public void PointerUpJump()
    {
        MoveJump = false;
    }

    public void PointerDownCrouch()
    {
        MoveCrouch = true;
    }
    public void PointerUpCrouch()
    {
        MoveCrouch = false;
    }


    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            float horiz = Input.GetAxisRaw("Horizontal");


            // Rb.velocity = new Vector2(ms * horiz, Rb.velocity.y);

            if ((horiz > 0 || MoveRight) && !MoveLeft)
            {
                Rb.velocity = new Vector2(ms, Rb.velocity.y);
                myAnimator.SetBool("isRunning", true);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                lastDirection = 1;
            }
            else if ((horiz < 0 || MoveLeft) && !MoveRight)
            {
                Rb.velocity = new Vector2(-ms, Rb.velocity.y);
                myAnimator.SetBool("isRunning", true);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                lastDirection = -1;
            }
            else
            {
                myAnimator.SetBool("isRunning", false);
            }


            if ((MoveJump || Input.GetButtonDown("Jump")) && isJumping == false)
            {
                Rb.AddForce(new Vector2(0, jf));
                isJumping = true;
                myAnimator.SetBool("isJump", true);

                StartCoroutine(ResetJumpAnimation());
            }

            // Menambahkan relasi animasi "falling"
            if (Rb.velocity.y < -0.1f)
            {
                isFalling = true;
                myAnimator.SetBool("isFalling", true);
            }
            else
            {
                isFalling = false;
                myAnimator.SetBool("isFalling", false);
            }

            if ((MoveCrouch || Input.GetKey(KeyCode.C)) && horiz == 0) // Tombol C sedang ditekan
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
    }



    IEnumerator ResetJumpAnimation()
    {
        yield return new WaitForSeconds(1f);
        myAnimator.SetBool("isJump", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            myAnimator.SetBool("isJump", false);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            // Mengabaikan sentuhan dengan musuh
            Physics2D.IgnoreCollision(other.collider, Collider);
        }
    }
}
