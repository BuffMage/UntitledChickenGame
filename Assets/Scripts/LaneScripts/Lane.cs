using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    [SerializeField]
    private LaneEnumerator laneType;
    [SerializeField]
    private float laneWidth;
    [SerializeField]
    private float laneSpeed;

    public float getXPosition()
    {
        return transform.position.x;
    }

    public float getLaneWidth()
    {
        return laneWidth;
    }
    
    public void setLaneWidth(float width)
    {
        laneWidth = width;
    }

    public LaneEnumerator getLaneType()
    {
        return laneType;
    }

    public float getLaneSpeed()
    {
        return laneSpeed;
    }

    public void setLaneSpeed(float newLaneSpeed)
    {
        laneSpeed = newLaneSpeed;
    }
}
