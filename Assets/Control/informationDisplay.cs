using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class informationDisplay : MonoBehaviour
{
    /*======================================+Connects to screen inputs+===================================*/
    public Text inputName;
    public InputField inputMight;
    public InputField inputEndurance;
    public InputField inputFinesse;
    public InputField inputMind;
    public InputField inputSoul;
    public Text inputSkillPoints;
    public Dropdown weakness;
    /*======================================-Connects to screen inputs-===================================*/
    void Start()
    {
        if (weakness != null)
        {
            weakness.onValueChanged.AddListener(resetAttributes);
        }
    }


   
    
     
    public void resetAttributes(int placeHolder)
    {

       // inputName.text = "John";


        if (inputMight != null && inputEndurance != null && inputFinesse != null && inputMind != null && inputSoul != null)
        {
            inputMight.text = "0";
            inputEndurance.text = "0";
            inputFinesse.text = "0";
            inputMind.text = "0";
            inputSoul.text = "0";
        }
        
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
