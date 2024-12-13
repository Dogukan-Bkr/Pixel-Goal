using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5;
    public float jumpSpeed = 7;
    public Transform groundCheckTr;
    private float groundCheckDistance = 0.1f;
    private Animator characterAnimator;
    public bool isPlayer;
    public float horizontalInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPlayer)
        {
            horizontalMovementUpdate();  // Yatay hareket sadece oyuncu için
            checkJump();                  // Zýplama kontrolü sadece oyuncu için
        }
    }

    private void horizontalMovementUpdate()
    {
        // Yatay hareket için input al
        horizontalInput = Input.GetAxis("Horizontal");

        // Rigidbody2D'yi kullanarak yatay hareketi yap
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Animator'a hýz bilgisini gönder
        characterAnimator.SetFloat("velocityMagnitude", Mathf.Abs(rb.velocity.x));
    }

    private void checkJump()
    {
        // Zýplama iþlemi sadece oyuncu için
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (IsGrounded())
            {
                // Zýplama iþlemi
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

                // Animasyonu zýplama ile tetikle
                characterAnimator.SetTrigger("Jump");
            }
        }
    }

    private bool IsGrounded()
    {
        // Yer kontrolü yapmak için raycast kullan
        var hit = Physics2D.Raycast(groundCheckTr.position, Vector2.down, groundCheckDistance);

        // Eðer yere temas varsa true döndür
        return hit.collider != null;
    }
}
