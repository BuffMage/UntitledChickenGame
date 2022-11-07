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
        float position = -30;
        while (position < 30)
        {
            position += Random.Range(14, 25);
            SpawnCar(position);
        }
        Invoke("SpawnCar", Random.Range(spawnRateRange.x, spawnRateRange.y));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCar(float position)
    {
        Vector3 newSpawnpoint = carSpawnPoint.position;
        newSpawnpoint.z += position;

        GameObject newCar = Instantiate(carObject, newSpawnpoint, this.transform.rotation);
        DefaultCar carComp = newCar.GetComponent<DefaultCar>();
        carComp.SetSpeed(getLaneSpeed());
        carComp.transform.SetParent(this.gameObject.transform);
        //Invoke("SpawnCar", Random.Range(spawnRateRange.x, spawnRateRange.y));
        carComp.SetLane(this);
    }

    public void SpawnCar()
    {
        GameObject newCar = Instantiate(carObject, carSpawnPoint.position, this.transform.rotation);
        DefaultCar carComp = newCar.GetComponent<DefaultCar>();
        carComp.SetSpeed(getLaneSpeed());
        carComp.transform.SetParent(this.gameObject.transform);
        Invoke("SpawnCar", Random.Range(spawnRateRange.x, spawnRateRange.y));
        carComp.SetLane(this);
    }



}
