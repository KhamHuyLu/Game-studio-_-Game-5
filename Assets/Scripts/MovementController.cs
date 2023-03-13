using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    Vector2 move;
    public int speed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        flip();
    }
    private void FixedUpdate()
    {
        rb.AddForce (move * speed, ForceMode2D.Impulse);
    }

    void flip()
    {
        if (move.x < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
        if (move.x > 0.01f) transform.localScale = new Vector3(1, 1, 1);
    }
}
