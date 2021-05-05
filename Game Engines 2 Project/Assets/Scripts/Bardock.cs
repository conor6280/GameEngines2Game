using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bardock : MonoBehaviour
{
    public float timestamp = 0;
    public float coolDown = 7.0f;
    public float speed = 1;

    private Vector3 scaleChange, scaleReset, blastScale, blastPos;

    public GameObject goAway;
    public GameObject blast;
    public GameObject Path;

    void Start()
    {
        timestamp = Time.time + coolDown;
        scaleChange = new Vector3(20.0f, 20.0f, 20.0f);
        scaleReset = new Vector3(0.1f, 0.1f, 0.1f);
        blastScale = new Vector3(0.025f, 0.5f, 0.025f);
        blastPos = new Vector3(0.0f, 1.8f, -3.1f);
    }

    void FixedUpdate()
    {
        if (Time.time >= 0.0f && Time.time <= 5.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Path.GetComponent<StoreWaypoints>().waypoints[0].transform.position, speed * Time.deltaTime);
        }

        if (Time.time >= 8.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Path.GetComponent<StoreWaypoints>().waypoints[1].transform.position, speed * Time.deltaTime);
        }

        if (timestamp <= Time.time)
        {
            timestamp = Time.time + 10000;
            goAway.transform.localScale += scaleChange;
        }

        if (Time.time >= 8.0f)
        {
            goAway.transform.localScale = scaleReset;
        }

        if (Time.time >= 10.0f && Time.time <= 12.0f)
        {
            blast.transform.localScale += blastScale;
        }

        if (Time.time >= 10.0f && Time.time <= 17.0f)
        {
            blast.transform.position += blastPos;
        }

        if (Time.time >= 17.0f)
        {
            Destroy(blast);
        }
    }
}
