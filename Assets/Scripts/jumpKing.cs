using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class jumpKing : MonoBehaviour
{
    //jump power indicator
    [SerializeField] private JumpBar jumpBar;

    //audio
    [SerializeField] private AudioSource soundManager;
    [SerializeField] private AudioClip jumpAUD;

    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;

    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = 0.0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        Application.targetFrameRate = 60;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        }


        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
        new Vector2(0.9f, 0.4f), 0f, groundMask);

        if (jumpValue > 0) 
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }

        if(Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += 0.6f;
            jumpBar.SetJump(jumpValue);
        }
        else
        {
            jumpBar.SetJump(0);
        }

        if (Input.GetKeyDown("space") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            //Jump(new Vector2(0.0f, rb.velocity.y));
        }

        if (jumpValue>= 20f && isGrounded)
        {
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            //rb.velocity = new Vector2(tempx, tempy);
            Jump(new Vector2(tempx, tempy));
            Invoke("ResetJump", 0.2f);
            soundManager.PlayOneShot(jumpAUD);
        }

        if (Input.GetKeyUp("space"))
        {
            if (isGrounded)
            {
                //rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                Jump(new Vector2(moveInput * walkSpeed, jumpValue));
                jumpValue = 0.0f;
                soundManager.PlayOneShot(jumpAUD);
            }
            canJump = true;
        }
        

    }
    
    private void Jump(Vector2 jumpVector)
    {
        rb.velocity = jumpVector;
        //itween...........
        iTween.PunchScale(gameObject, new Vector3(0, jumpValue/10, 0), 0.5f);
    }

    void ResetJump()
    {
        //canJump = false;
        jumpValue = 0;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(1f, 0.2f));
    }
}
