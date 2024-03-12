using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehaviour : MonoBehaviour
{

    private Vector3 startPosition;
    private Quaternion startRotation;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Tab)) 
        {
            ThrowDart();
        }
    }

    public void ThrowDart()
    {
        Invoke("ResetDart", 3.0f);
    }
    
    IEnumerator ResetDart()
    {
        print("balls");
        transform.position = startPosition;
        transform.rotation = startRotation;
        rb.useGravity = true;
        print("balls2");
        return null;
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Wall")) 
        {
            rb.useGravity = false;
        }
    }
}
