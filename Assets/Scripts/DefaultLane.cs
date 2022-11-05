using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLane : Lane
{
    // Start is called before the first frame update
    void Start()
    {
        setLaneWidth(this.GetComponent<BoxCollider>().bounds.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
