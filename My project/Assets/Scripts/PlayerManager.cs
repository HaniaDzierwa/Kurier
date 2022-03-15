using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerManager : MonoBehaviour
{
    

    [Header("SteeringVariables")]
    public float acceleration;
    public float steeringPower;
    public float steeringAmount, speed, direction;

    public bool movement = true;

  


    [Header("Components")]
    private InputManager inputManager;
    private Rigidbody2D rigBod;
    
    private GameManager gameManager;

    //load from file bedzie
    public Car currentlySelectedCar;


    void Start()
    {
        GameObject xd = GameObject.Find("ResourcesManager");
        MyResources res = xd.GetComponent<MyResources>();
        currentlySelectedCar = res.cars[0];

        this.gameManager = FindObjectOfType<GameManager>();
        this.rigBod = GetComponent<Rigidbody2D>();
        this.inputManager = GetComponent<InputManager>();
        this.acceleration = 30f;
        this.steeringPower = 0.5f;
       
     
    }


    public void Reskin(int i)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

       

        this.acceleration= currentlySelectedCar.acceleration;
        this.steeringPower = currentlySelectedCar.steeringPower;
        renderer.sprite = currentlySelectedCar.sprite;


                
            
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //wykryc kolizje z wejsciem garazu
        GameObject garage = GameObject.Find("Garage");
        if (collision.gameObject.tag == "Garage")
        {
            //z gameManager wywolac zmiane sceny
            this.gameObject.transform.position = Vector2.zero;
            rigBod.velocity = Vector2.zero;
            rigBod.rotation = 180;
            gameManager.enterGarage();
            movement = false;
            Debug.Log("garage");
           
        }
       
        


        Node colidedNode = collision.gameObject.GetComponent<Node>();
        if (!colidedNode)
            return;
        this.gameManager.playerAndNodeColiision(colidedNode.getIdNode());


    }
    void FixedUpdate()
    {
        if (movement == true)
        {
            this.movePlayer();
        }
    }

    private void movePlayer()
    {

        steeringAmount = -inputManager.horizontal;
        speed = inputManager.vertical * acceleration;
        direction = Mathf.Sign(Vector2.Dot(rigBod.velocity, rigBod.GetRelativeVector(Vector2.up)));
        rigBod.rotation += steeringAmount * steeringPower * rigBod.velocity.magnitude * direction;
        rigBod.AddRelativeForce(Vector2.up * speed);
        rigBod.AddRelativeForce(-Vector2.right * rigBod.velocity.magnitude * steeringAmount / 2);
    }



    
}

