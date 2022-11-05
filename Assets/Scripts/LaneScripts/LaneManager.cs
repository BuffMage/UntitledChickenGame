using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    private static List<Lane> lanes;
    [SerializeField]
    private int numLanes;
    [SerializeField]
    private float spawnOffset;

    [SerializeField]
    private GameObject[] lanePrefabs;
    public static bool areLanesReady = false;


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
        this.transform.position = new Vector3(spawnOffset, 0, 0);
        areLanesReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLane(int index, LaneEnumerator laneType)
    {
        GameObject laneToCreate = lanePrefabs[(int)laneType];
        Vector3 spawnPosition = Vector3.zero;
        GameObject newLane = Instantiate(laneToCreate, spawnPosition, Quaternion.identity);
        Lane laneComp = newLane.GetComponent<Lane>();
        if (index != 0)
        {
            newLane.transform.position += new Vector3(lanes[index - 1].gameObject.transform.position.x + lanes[index - 1].getLaneWidth() / 2 + laneComp.getLaneWidth() / 2, 0, 0);
        }
        lanes.Add(laneComp);
        newLane.transform.SetParent(this.gameObject.transform);
    }

    public static float getLanePosition(int index)
    {
        return lanes[index].getXPosition();
    }

    public static int getNumLanes()
    {
        return lanes.Count;
    }
}
