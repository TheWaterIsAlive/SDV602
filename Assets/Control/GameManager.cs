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

    private bool gameRunning;

    //public gameModel gameModel;
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
           // gameModel = new gameModel();

        }
        else
        {
            Destroy(gameObject);
        }

    }
    /*======================================-Awake Code-===================================*/


    /*======================================+Check if game is running+===================================*/
    public bool isGameRunning()
    {
        return gameRunning;
    }
    /*======================================-Check if game is running-===================================*/

    /*======================================+Change Scene to game+===================================*/
    public void changeScene()
    {
        SceneManager.LoadScene("game");

    }
    /*======================================-Change Scene to game-===================================*/
}
