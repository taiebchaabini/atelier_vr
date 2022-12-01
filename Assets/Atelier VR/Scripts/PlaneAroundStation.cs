using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAroundStation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rotate = transform.rotation;
        rotate.y += 1;
        transform.rotation = rotate;
    }
}
