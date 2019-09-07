using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class informationDisplay : MonoBehaviour
{
    /*======================================+Connects to screen inputs+===================================*/
    public Text inputName;
    /*======================================-Connects to screen inputs-===================================*/
    void Start()
    {
      

    }





    /*======================================+Code for when confirm is pressed+===================================*/
    public void confirmCreation()
    {
        /*
         * Makes playerCharacter a new character.
         * Sets the elements of new character to that of what has been entered.
         * Loads the next scene.
         */

        GameManager.instance.gameModel.playerCharacter = new character();
        GameManager.instance.gameModel.playerCharacter.Name = inputName.text;
        SceneManager.LoadScene("game");

    }

    /*======================================-Code for when confirm is pressed-===================================*/



}
