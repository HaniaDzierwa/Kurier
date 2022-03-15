using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name != "Game")
        {
            GetComponent<RawImage>().enabled = false;
        }
        else
        {
            GetComponent<RawImage>().enabled = true;
        }
    }
}
