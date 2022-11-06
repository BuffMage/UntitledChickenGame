using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLordManager : MonoBehaviour
{
    private Vector2Int selectedLanes = new Vector2Int(-1, -1);
    private Vector2 selectedLaneSpeeds;
    private Vector2 originalSpeeds;
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
            if (selectedLanes.x == GameManager.GetActiveLanes().y - 1)
            {
                LaneManager.SpeedUpLane(selectedLanes.x, originalSpeeds.x, .5f);
                selectedLanes.x = -1;
            }
            else
            {
                selectedLanes.x = GameManager.GetActiveLanes().y - 1;
                originalSpeeds.x = LaneManager.GetLaneSpeed(selectedLanes.x);
                selectedLaneSpeeds.x = originalSpeeds.x;
            }
        }
        SlowLane();
        
    }

    void SlowLane()
    {
        if (selectedLanes.x != -1)
        {
            selectedLaneSpeeds.x -= deceleration * Time.deltaTime;
            selectedLaneSpeeds.x = Mathf.Clamp(selectedLaneSpeeds.x, 0, originalSpeeds.x);
            LaneManager.SetLandSpeed(selectedLanes.x, selectedLaneSpeeds.x);
        }
    }


}
