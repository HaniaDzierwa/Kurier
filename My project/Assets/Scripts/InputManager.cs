using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float vertical;
    public float horizontal;
    public bool brake;
   
    void Update()
    {
        vertical = -Input.GetAxis("Vertical");
        horizontal = -Input.GetAxis("Horizontal");
        brake = Input.GetKey(KeyCode.Space);
    }
}
