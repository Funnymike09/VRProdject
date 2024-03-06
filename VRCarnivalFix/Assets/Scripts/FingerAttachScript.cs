using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerAttachScript : MonoBehaviour
{ 
    Collider Fingers;
    public GameObject IndexLSR;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "IndexL")
        {
            IndexLSR.active = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
