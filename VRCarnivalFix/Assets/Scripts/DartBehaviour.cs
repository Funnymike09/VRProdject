using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehaviour : MonoBehaviour
{

    private Transform startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform;
    }

    public void ThrowDart()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 90, -180);
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 250, ForceMode.Force);
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        Invoke("ResetDart", 3.0f);
    }
    
    IEnumerator ResetDart()
    {
        var o = gameObject;
        o.transform.position = startPosition.position;
        o.transform.rotation = startPosition.rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        yield return null;
    }
}
