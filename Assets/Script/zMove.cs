using UnityEngine;

public class zMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // private bool isJumping = false;
    private bool isGrounded = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Memeriksa apakah karakter berada di atas tanah
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Input horizontal (gerakan kiri dan kanan)
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Gerakan horizontal
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Mengubah arah karakter
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // Input lompat
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            // isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Memeriksa jika karakter menyentuh tanah
        if (collision.gameObject.CompareTag("Ground"))
        {
            // isJumping = false;
        }
    }
}
