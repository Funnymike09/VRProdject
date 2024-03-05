using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehaviour : MonoBehaviour
{

    private Transform startPosition;

    private IEnumerator _resetDart;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowDart()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 90, -180);
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 250, ForceMode.Force);
        _resetDart = ResetDart();
    }
    
    IEnumerator ResetDart()
    {
        yield return new WaitForSeconds(3);
        var o = gameObject;
        o.transform.position = startPosition.position;
        o.transform.rotation = startPosition.rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
