using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCar : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
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
}
