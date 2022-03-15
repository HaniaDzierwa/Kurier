using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyResources : MonoBehaviour
{
    public Car[] cars;
    Sprite[] spirtiesTable;

   
    void Awake()
    {
        spirtiesTable = Resources.LoadAll<Sprite>("");

        Car[] carsInit = {

            new Car("a", 40f, 0.6f, spirtiesTable[0]),
            new Car("ab", 60f, 0.3f, spirtiesTable[1]),
            new Car("ac", 20f, 0.8f, spirtiesTable[2]),
            new Car("ad", 35f, 0.1f, spirtiesTable[3]),
            new Car("aas", 55f, 0.5f, spirtiesTable[4]),
            new Car("aasdasd", 80f, 0.2f, spirtiesTable[5]),
            new Car("aqweqw", 10f, 0.9f, spirtiesTable[6]),
            new Car("aasdasdzxczx", 50f, 0.6f, spirtiesTable[7])

        };
        this.cars = carsInit;
    }

    // Update is called once per frame
   
}
