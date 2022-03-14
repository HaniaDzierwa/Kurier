using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliverdPackage : MonoBehaviour
{
    public Collider2D tileColider;
    public bool deliverdPackage = false;
   
    void Awake()
    {
        tileColider = GetComponent<Collider2D>();
        

    }

    

    private void OnTriggerEnter2D(Collider2D other) // handle picking 
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        deliverdPackage = true;

       

    }

    public void resetDeliverPoint()
    {
        this.deliverdPackage = false;
    }
}
