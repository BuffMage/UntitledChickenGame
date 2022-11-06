using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLordManager : MonoBehaviour
{
    private int selectedLane = -1;
    private float selectedLaneSpeed;
    private float originalSpeed;
    [SerializeField]
    private float deceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            if (selectedLane == -1)
            {
                selectedLane = GameManager.GetActiveLanes().y - 1;
                originalSpeed = LaneManager.GetLaneSpeed(selectedLane);
                selectedLaneSpeed = originalSpeed;
            }
            else if (selectedLane != GameManager.GetActiveLanes().y - 1)
            {
                LaneManager.SpeedUpLane(selectedLane, originalSpeed, 2f);
                selectedLane = GameManager.GetActiveLanes().y - 1;
                originalSpeed = LaneManager.GetLaneSpeed(selectedLane);
                selectedLaneSpeed = originalSpeed;
            }
            else
            {
                LaneManager.SpeedUpLane(selectedLane, originalSpeed, 2f);
                selectedLane = -1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Period))
        {
            if (selectedLane == -1)
            {
                selectedLane = GameManager.GetActiveLanes().y - 2;
                originalSpeed = LaneManager.GetLaneSpeed(selectedLane);
                selectedLaneSpeed = originalSpeed;
            }
            else if (selectedLane != GameManager.GetActiveLanes().y - 2)
            {
                LaneManager.SpeedUpLane(selectedLane, originalSpeed, 2f);
                selectedLane = GameManager.GetActiveLanes().y - 2;
                originalSpeed = LaneManager.GetLaneSpeed(selectedLane);
                selectedLaneSpeed = originalSpeed;
            }
            else
            {
                LaneManager.SpeedUpLane(selectedLane, originalSpeed, 2f);
                selectedLane = -1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Comma))
        {
            if (selectedLane == -1)
            {
                selectedLane = GameManager.GetActiveLanes().y - 3;
                originalSpeed = LaneManager.GetLaneSpeed(selectedLane);
                selectedLaneSpeed = originalSpeed;
            }
            else if (selectedLane != GameManager.GetActiveLanes().y - 3)
            {
                LaneManager.SpeedUpLane(selectedLane, originalSpeed, 2f);
                selectedLane = GameManager.GetActiveLanes().y - 3;
                originalSpeed = LaneManager.GetLaneSpeed(selectedLane);
                selectedLaneSpeed = originalSpeed;
            }
            else
            {
                LaneManager.SpeedUpLane(selectedLane, originalSpeed, 2f);
                selectedLane = -1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            if (selectedLane == -1)
            {
                selectedLane = GameManager.GetActiveLanes().y - 4;
                originalSpeed = LaneManager.GetLaneSpeed(selectedLane);
                selectedLaneSpeed = originalSpeed;
            }
            else if (selectedLane != GameManager.GetActiveLanes().y - 4)
            {
                LaneManager.SpeedUpLane(selectedLane, originalSpeed, 2f);
                selectedLane = GameManager.GetActiveLanes().y - 4;
                originalSpeed = LaneManager.GetLaneSpeed(selectedLane);
                selectedLaneSpeed = originalSpeed;
            }
            else
            {
                LaneManager.SpeedUpLane(selectedLane, originalSpeed, 2f);
                selectedLane = -1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            if (selectedLane == -1)
            {
                selectedLane = GameManager.GetActiveLanes().y - 5;
                originalSpeed = LaneManager.GetLaneSpeed(selectedLane);
                selectedLaneSpeed = originalSpeed;
            }
            else if (selectedLane != GameManager.GetActiveLanes().y - 5)
            {
                LaneManager.SpeedUpLane(selectedLane, originalSpeed, 2f);
                selectedLane = GameManager.GetActiveLanes().y - 5;
                originalSpeed = LaneManager.GetLaneSpeed(selectedLane);
                selectedLaneSpeed = originalSpeed;
            }
            else
            {
                LaneManager.SpeedUpLane(selectedLane, originalSpeed, 2f);
                selectedLane = -1;
            }
        }
        SlowLane();
        
    }

    void SlowLane()
    {
        if (selectedLane != -1)
        {
            selectedLaneSpeed -= deceleration * Time.deltaTime;
            selectedLaneSpeed = Mathf.Clamp(selectedLaneSpeed, 0, originalSpeed);
            LaneManager.SetLandSpeed(selectedLane, selectedLaneSpeed);
        }
    }


}
