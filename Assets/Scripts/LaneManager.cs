using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    private List<Lane> lanes;
    [SerializeField]
    private int numLanes;
    [SerializeField]
    private float spawnOffset;

    private GameObject[] lanePrefabs;


    // Start is called before the first frame update
    void Start()
    {
        lanes = new List<Lane>();
        for (int i = 0; i < numLanes; i++)
        {
            if (i % 3 == 0)
            {
                SpawnLane(i, LaneEnumerator.BlankLane);
            }
            else
            {
                SpawnLane(i, LaneEnumerator.DefaultLane);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLane(int index, LaneEnumerator laneType)
    {
        GameObject laneToCreate = lanePrefabs[(int)laneType];
        Vector3 spawnPosition = Vector3.zero;
        spawnPosition.x = spawnOffset;
        GameObject newLane = Instantiate(laneToCreate, spawnPosition, Quaternion.identity);
        Lane laneComp = newLane.GetComponent<Lane>();
        if (index != 0)
        {
            newLane.transform.position += new Vector3(lanes[index - 1].getLaneWidth() / 2 + laneComp.getLaneWidth(), 0, 0);
        }
        lanes.Add(laneComp);
        
        
    }
}
