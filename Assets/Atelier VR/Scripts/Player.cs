using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (transform.position.y < -3)
        {
            // transform.parent.position = transform.TransformPoint(new Vector3(-0.290079892f,-7.88947487f,-0.0486988723f));
            transform.position = new Vector3(57.8699989f,2f,85.9700012f);
            transform.rotation = Quaternion.identity;
        }
    }
}
