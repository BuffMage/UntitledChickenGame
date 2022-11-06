using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCar : MonoBehaviour
{
    private float speed;
    private Lane lane;


    // Start is called before the first frame update
    void Start()
    {
        //MeshRenderer mr = GetComponentsInChildren<MeshRenderer>()[1];
        //mr.materials[1].SetColor("_Albedo", carColors[0].GetColor("_Albedo"));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * lane.getLaneSpeed() * Time.deltaTime, Space.Self);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().SetDead();
        }
    }

    public void SetLane(Lane lane)
    {
        this.lane = lane;
    }
}
