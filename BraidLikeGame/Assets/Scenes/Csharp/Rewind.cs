using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Rewind : MonoBehaviour
{
    public MonoBehaviour movementScript;
    public Transform playerTransform;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D playerRigidbody;

    bool rewinding;
    
    Stack<Vector3> positions = new Stack<Vector3>(); 
    Stack<bool> rotations = new Stack<bool>();

    // STACK SE COMPORTA COMO UNA LISTA DE LA CUAL SOLO PODEMOS SACARLE
    // EL ULTIMO VALOR QUE LE PUSIMOS
    void Update()
    {
        rewinding = Input.GetKey(KeyCode.E);

        if (!rewinding)
        {
            playerRigidbody.isKinematic = false;
            movementScript.enabled = true;

            positions.Push(transform.position);
            rotations.Push(spriteRenderer.flipX);
        }
        else
        {
            movementScript.enabled = true;

            if (positions.Count > 0)
            {
                playerRigidbody.isKinematic = false;
                playerTransform.position = positions.Pop();
                spriteRenderer.flipX = rotations.Pop();
            }
            else
            {
                playerRigidbody.isKinematic = true;
            }
        }

    }

}