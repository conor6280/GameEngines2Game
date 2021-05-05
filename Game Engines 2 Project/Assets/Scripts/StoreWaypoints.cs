using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreWaypoints : MonoBehaviour
{
    int nextIndex;
    public Transform[] waypoints;

    public Transform NextWaypoint(Transform current)
    {
        if (current != null)
        {
            for (int i = 0; i < waypoints.Length; i++)
            {
                if (current == waypoints[i])
                {
                    nextIndex = (i + 1) % waypoints.Length;
                }
            }
        }
        else
        {
            nextIndex = 0;
        }
        return waypoints[nextIndex];
    }
}
