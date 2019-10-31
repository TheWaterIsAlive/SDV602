using Assets.Model;
using Assets.Model.SQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   
    /*===============================+Creates instances of the important game classes+=========================*/
    public static GameManager instance;
   
    /* 
     * Beccause there is only one instance
     * of the GameManger we will have consistency
     * between screens
     */


    private DataService _databaseServices = new DataService("handsOfTheMaster.db");
    public DataService DatabaseServices { get => _databaseServices; set => _databaseServices = value; }

    private bool gameRunning;

    private void Start()
    {
        _databaseServices.CreateDB(new[] {
           typeof(user),
           typeof(sqlCharacter),
           /*
           typeof(sqlMyMap),
           typeof(sqlMapGrid),
           typeof(sqlScenes),
           */

    });

        Debug.Log("Start");
    }

    public gameModel gameModel;

    

    /*===============================-Creates instances of the important game classes-=========================*/


    /*======================================+Awake Code+===================================*/


    /*
     * If the no copies of game manager exist then
     * create a copy and set the game to running
     * else Destroy any un-need gameObjects
     */

  


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameRunning = true;
            Debug.Log("Game has started");
            gameModel = new gameModel();
            Debug.Log("Awake If");

        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Else If");
        }

    }
    /*======================================-Awake Code-===================================*/


    /*======================================+Check if game is running+===================================*/
    public bool isGameRunning()
    {
        return gameRunning;
        Debug.Log("gameRuninng");
    }
    /*======================================-Check if game is running-===================================*/

    /*======================================+Change Scene to game+===================================*/
    public void changeScene()
    {
        Debug.Log("Before Game load");
        SceneManager.LoadScene("game");


    }
    /*======================================-Change Scene to game-===================================*/
}
