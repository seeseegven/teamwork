using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movepoints : MonoBehaviour
{

    public static Movepoints Instance { get; private set; }

    public List<Transform> movePointsList;

    private void Awake()
    {
        Instance = this;
        Init(); 
    }   


    private void Init()
    {
        Transform[] transforms = transform.GetComponentsInChildren<Transform>();
        movePointsList = new List<Transform>(transforms);
        movePointsList.RemoveAt(0);
    }

    public int GetLength()
    {
        return movePointsList.Count;
    }
    public Vector3 GetWaypoint(int index)
    {
        return movePointsList[index].position;
    }
}
