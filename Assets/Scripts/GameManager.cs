using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private bool gameRunning;

    public gameModel gameModel;
    

    // What is Awake?
    // What other handlers are there?
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameRunning = true;
            Debug.Log("Game has started");
            gameModel = new gameModel();

        }
        else
        {
            Destroy(gameObject);
        }

    }

    public bool isGameRunning()
    {
        return gameRunning;
    }

    public void changeScene()
    {
        SceneManager.LoadScene("game");

    }
}
