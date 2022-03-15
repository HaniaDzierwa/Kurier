using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car {


    public string name;
    public float acceleration;
    public float steeringPower;

    public Sprite sprite;
    public Car(string name, float acceleration, float steeringPower, Sprite sprite)
    {
        this.name = name;
        this.acceleration = acceleration;
        this.steeringPower = steeringPower;
        this.sprite = sprite;
    }


}