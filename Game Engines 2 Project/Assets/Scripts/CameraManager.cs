using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;
    public GameObject Camera5;



    void Update()
    {
        if (Time.time >= 8.0f)
        {
            Camera.SetActive(false);
            Camera1.SetActive(true);
        }

        if (Time.time >= 9.0f)
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
        }

        if (Time.time >= 10.0f)
        {
            Camera2.SetActive(false);
            Camera3.SetActive(true);

        }

        if (Time.time >= 20.0f)
        {
            Camera3.SetActive(false);
            Camera4.SetActive(true);
        }

        if (Time.time >= 27.0f)
        {
            Camera4.SetActive(false);
            Camera5.SetActive(true);
        }
    }
}
