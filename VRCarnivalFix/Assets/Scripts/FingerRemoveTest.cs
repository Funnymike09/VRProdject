using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FingerRemoveTest : MonoBehaviour
{

    public GameObject[] leftFingers;
    public GameObject[] rightFingers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject fingers in leftFingers)
            {
                //fingers.GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
        }
    }
}
