using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TimeControl : MonoBehaviour
{
    public MonoBehaviour movementScript;
    public float saveFrequency = 0.1f;

    bool rewinding;
    Rigidbody rb;
    Stack<Vector3> positions = new Stack<Vector3>();
    Stack<Quaternion> rotations = new Stack<Quaternion>();
                
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("SavePosition", 0, saveFrequency);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Rewind();
        }
    }

    void SavePosition()
    {
        if (rewinding)
            return;
        positions.Push(transform.position);
        rotations.Push(transform.rotation);
    }

    void Rewind()
    {
        if (rewinding)        
            return;
        
        StartCoroutine(RewindCoroutine());
    }

    IEnumerator RewindCoroutine()
    {
        rewinding = true;
        movementScript.enabled = false;
        rb.isKinematic = true;

        while (positions.Count > 0 && Input.GetKey(KeyCode.R))
        {
            print(positions.Count);
            transform.position = positions.Pop();
            transform.rotation = rotations.Pop();
            yield return new WaitForSeconds(saveFrequency);
        }
   

        movementScript.enabled = true;
        rb.isKinematic = false;
        rewinding = false;

    }

}
