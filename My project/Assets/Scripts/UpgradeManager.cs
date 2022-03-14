using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class UpgradeManager : MonoBehaviour
{
    GameObject player;
    string gameSceneName;

    
   
    // Start is called before the first frame update
    void Start()
    {
       

        gameSceneName = "Game";
        player = GameObject.Find("Player");
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

        player.gameObject.GetComponent<SpriteRenderer>().sprite.name = "Assets/SpriteCar/car_people3.png";




    }

}
