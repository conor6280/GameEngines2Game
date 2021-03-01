using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public static GameObject Target;

    void Start()
    {
        Vector3 Attack = new Vector3(Target.transform.position);
    }

    void Update()
    {
        
    }
}
