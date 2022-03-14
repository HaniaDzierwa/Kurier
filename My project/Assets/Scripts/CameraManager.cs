using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject car;

    void Start()
    {
        car = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Camera.main.transform.position = new Vector3(car.transform.position.x, car.transform.position.y, -10);
    }
}
