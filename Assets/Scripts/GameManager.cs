using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private static Vector2Int activeLanes = new Vector2Int(0, 6);
    [SerializeField]
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetIndex() == activeLanes.y)
        {
            activeLanes += Vector2Int.one * (activeLanes.y - activeLanes.x);
        }
    }
    public static Vector2Int GetActiveLanes()
    {
        return activeLanes;
    }

}
