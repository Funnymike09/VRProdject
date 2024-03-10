using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehaviour : MonoBehaviour
{

    private Transform startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform;
    }

    public void ThrowDart()
    {
        StartCoroutine("ResetDart");
    }
    
    IEnumerator ResetDart()
    {
        yield return new WaitForSeconds(3);
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
    }
}
