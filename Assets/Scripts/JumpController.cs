using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Jump System")]
    [SerializeField] float jumpTime;
    [SerializeField] int jumpPower;
    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpMultiplier;

    public Transform groundCheck;
    public LayerMask groundLayer;
    Vector2 vecGravity;

    bool isJumping;
    float jumpCounter;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
        }

        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            rb.velocity += vecGravity * jumpMultiplier * Time.captureDeltaTime;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = false;
            jumpCounter = 0;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }
        if (rb.velocity.y<0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.18f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
