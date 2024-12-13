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
            horizontalMovementUpdate();  // Yatay hareket sadece oyuncu i�in
            checkJump();                  // Z�plama kontrol� sadece oyuncu i�in
        }
    }

    private void horizontalMovementUpdate()
    {
        // Yatay hareket i�in input al
        horizontalInput = Input.GetAxis("Horizontal");

        // Rigidbody2D'yi kullanarak yatay hareketi yap
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Animator'a h�z bilgisini g�nder
        characterAnimator.SetFloat("velocityMagnitude", Mathf.Abs(rb.velocity.x));
    }

    private void checkJump()
    {
        // Z�plama i�lemi sadece oyuncu i�in
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (IsGrounded())
            {
                // Z�plama i�lemi
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

                // Animasyonu z�plama ile tetikle
                characterAnimator.SetTrigger("Jump");
            }
        }
    }

    private bool IsGrounded()
    {
        // Yer kontrol� yapmak i�in raycast kullan
        var hit = Physics2D.Raycast(groundCheckTr.position, Vector2.down, groundCheckDistance);

        // E�er yere temas varsa true d�nd�r
        return hit.collider != null;
    }
}
