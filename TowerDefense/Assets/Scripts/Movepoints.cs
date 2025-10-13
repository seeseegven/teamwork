using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movepoints : MonoBehaviour
{
    public List<Transform> movePointsList;

    // Start is called before the first frame update
    void Start()
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
