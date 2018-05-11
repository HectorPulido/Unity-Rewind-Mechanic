using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("Control")]
    public float speed = 5;
    public float jumpSpeed = 5;

    SpriteRenderer sr;
    Rigidbody2D rb;

    bool ground;
    bool jumpRequest = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        rb.freezeRotation = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ground)        
            jumpRequest = true;        

        if (Input.GetAxis("Horizontal") != 0)
            sr.flipX = Input.GetAxis("Horizontal") < 0;
    }

    void FixedUpdate()
    {
        if (jumpRequest)
        {
            jumpRequest = false;
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        ground = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ground = false;
    }
}