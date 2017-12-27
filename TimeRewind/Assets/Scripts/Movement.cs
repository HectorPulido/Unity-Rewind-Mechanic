using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 1;
    public float JumpSpeed = 5;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
	void Update ()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, rb.velocity.z);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity += Vector3.up * JumpSpeed;
        }
	}
}
