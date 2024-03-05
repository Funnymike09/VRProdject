using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowDart()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 90, -180);
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000);
    }
}
