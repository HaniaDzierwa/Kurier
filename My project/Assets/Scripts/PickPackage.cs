using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PickPackage : MonoBehaviour
{
    public Collider2D tileColider;
    public bool packagePicked = false; 
    
   
    void Awake()
    {
        tileColider = GetComponent<Collider2D>();
        
    }

   
    private void OnTriggerEnter2D(Collider2D other) // handle picking 
    {
        if (!other.CompareTag("Player")){
            return;
        }

        packagePicked = true;
        
        
        

    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name != "Game")
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public void resetPickPoint()
    {
        this.packagePicked = false;
    }
    
}
