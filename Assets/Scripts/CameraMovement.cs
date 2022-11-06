using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player;
    private Vector2 prevActiveLanes;
    private float cameraTimer = 0f;
    private Vector3 lastPos;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        prevActiveLanes = GameManager.GetActiveLanes();
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (prevActiveLanes != GameManager.GetActiveLanes())
        {
            cameraTimer = 0f;
            prevActiveLanes = GameManager.GetActiveLanes();
            lastPos = transform.position;
            targetPos = transform.position + Vector3.right * 34;
        }
        MoveForward();
    }

    private void MoveForward()
    {
        if (targetPos.sqrMagnitude == 0) return;
        cameraTimer += Time.deltaTime;
        Vector3 newPos = Vector3.Slerp(lastPos, targetPos, cameraTimer);
        newPos.y = lastPos.y;
        transform.position = newPos;

    }
}
