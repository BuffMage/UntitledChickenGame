using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLane : Lane
{
    private void Awake()
    {
        setLaneWidth(this.GetComponent<BoxCollider>().bounds.size.x);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
