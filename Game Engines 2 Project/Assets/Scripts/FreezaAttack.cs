using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreezaAttack : MonoBehaviour
{
    public GameObject supernova;
    public GameObject Path;

    private Vector3 scaleChange;
    private Vector3 posChange;
    private Vector3 originalScale;

    public float timestamp = 0;
    public float coolDown = 11.0f;
    public float speed = 5000.0f;

    void Start()
    {
        originalScale = supernova.transform.localScale;
        timestamp = Time.time + coolDown;
        scaleChange = new Vector3(0.8f, 0.8f, 0.8f);
        posChange = new Vector3(0.0f, 1.2f, 0.0f);
    }

    void FixedUpdate()
    {
        if (timestamp <= Time.time + 6 && timestamp >= Time.time)
        {
            supernova.transform.position += posChange;
            supernova.transform.localScale += scaleChange / 90;
        }

        if (Time.time >= 16.0f && Time.time <= 20.0f)
        {
            transform.position = Vector3.MoveTowards(supernova.transform.position, Path.GetComponent<StoreWaypoints>().waypoints[0].transform.position, speed);
        }

        if (Time.time >= 20.0f)
        {
            transform.position = Vector3.MoveTowards(supernova.transform.position, Path.GetComponent<StoreWaypoints>().waypoints[1].transform.position, speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ending")
        {
            Application.Quit();

        }
    }
}