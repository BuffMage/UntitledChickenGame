using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLane : Lane
{
    [SerializeField]
    private Vector2 laneSpeedRange;
    [SerializeField]
    private Vector2 spawnRateRange;
    [SerializeField]
    private GameObject carObject;
    [SerializeField]
    private Transform carSpawnPoint;
    private void Awake()
    {
        setLaneWidth(this.GetComponent<BoxCollider>().bounds.size.x);
        setLaneSpeed(Random.Range(laneSpeedRange.x, laneSpeedRange.y));
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCar", Random.Range(spawnRateRange.x, spawnRateRange.y));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCar()
    {
        GameObject newCar = Instantiate(carObject, carSpawnPoint.position, Quaternion.identity);
        newCar.GetComponent<DefaultCar>().SetSpeed(getLaneSpeed());
        Invoke("SpawnCar", Random.Range(spawnRateRange.x, spawnRateRange.y));
    }
}
