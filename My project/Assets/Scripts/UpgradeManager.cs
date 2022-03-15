using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class UpgradeManager : MonoBehaviour
{
    GameObject player;
    MyResources myResources;
    string gameSceneName;

    public int counter =0; 
   
    // Start is called before the first frame update
    void Start()
    {
       

        gameSceneName = "Game";
        player = GameObject.Find("Player");
        myResources = GameObject.Find("ResourcesManager").GetComponent<MyResources>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void  upgradeAcceleration()
    {
        player.GetComponent<PlayerManager>().acceleration += 5;
        
    }



    public void backToGame()
    {
        player.transform.position = new Vector2 (-25f, 13f);
        player.transform.rotation = Quaternion.identity;
        SceneManager.LoadScene(gameSceneName);
        player.GetComponent<PlayerManager>().movement = true;
        
        
    }


    public void changeCar()
    {
        Debug.Log(player.GetComponent<PlayerManager>().currentlySelectedCar.name);

        player.GetComponent<PlayerManager>().currentlySelectedCar = myResources.cars[5];
        Debug.Log(player.GetComponent<PlayerManager>().currentlySelectedCar.name);
        player.GetComponent<PlayerManager>().Reskin(counter);



    }


   public void ButtonClick()
    {
        counter++;
        if (counter > 7)
            counter = 0;

        
    }


}
