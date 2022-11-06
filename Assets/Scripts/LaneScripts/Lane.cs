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
    private float targetLaneSpeed;
    private float laneAcceleration;

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

    public virtual void SpeedUpTo(float speed, float acceleration)
    {
        laneSpeed = Mathf.MoveTowards(laneSpeed, speed, acceleration);
        laneAcceleration = acceleration;
        targetLaneSpeed = speed;
        Invoke(nameof(SpeedUpTo), .1f);
    }

    public void SpeedUpTo()
    {
        if (laneSpeed != targetLaneSpeed)
        {
            laneSpeed = Mathf.MoveTowards(laneSpeed, targetLaneSpeed, laneAcceleration);
            Invoke(nameof(SpeedUpTo), .1f);
        }
    }
}
