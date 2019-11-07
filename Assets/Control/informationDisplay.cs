using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Assets.Model;

public class informationDisplay : MonoBehaviour
{
    /*======================================+Connects to screen inputs+===================================*/
    public Text inputName;
    /*============+Feild for When Stats are introduced+===========*/
    /*
    public InputField inputMight;
    public InputField inputEndurance;
    public InputField inputFinesse;
    public InputField inputMind;
    public InputField inputSoul;
    public Text inputSkillPoints;
    */
    /*============-Feild for When Stats are introduced-===========*/

    /*==============+Feild To Hold Existing Dropdowns+============*/
    public Dropdown inputAlignment;
    public Dropdown inputBoon;
    public Dropdown inputFear;
    public Dropdown inputWeakness;
    public Dropdown inputVice;
    /*==============-Feild To Hold Existing Dropdowns-============*/

    /*======================================-Connects to screen inputs-===================================*/

    /*
     * Start: Adds a listener on start up to reset stats when the weakness
     * dropbox is changed.
     * 
     * resetAttributes: Preforms Code to reset stats on change.
     */

    void Start()
    {
        /*  if (weakness != null)
          {
              weakness.onValueChanged.AddListener(resetAttributes);
          }
          */
    }


    public void resetAttributes(int placeHolder)
    {

        // inputName.text = "John";


        /*  if (inputMight != null && inputEndurance != null && inputFinesse != null && inputMind != null && inputSoul != null)
          {
              inputMight.text = "0";
              inputEndurance.text = "0";
              inputFinesse.text = "0";
              inputMind.text = "0";
              inputSoul.text = "0";
          }
          */
    }



    /*======================================+Code for when confirm is pressed+===================================*/
    public void confirmCreation()
    {
        /*
         *1:Parses inputs to character manage to creat new character
         *2:Creates new map
         *3:Loads the next scene.
         */


        characterManager.createCharacter(inputName.text,
            inputBoon.options[inputBoon.value].text,
            inputAlignment.options[inputAlignment.value].text,
            inputFear.options[inputFear.value].text,
            inputWeakness.options[inputWeakness.value].text,
            inputVice.options[inputVice.value].text);

        mapManager.makeNewMap();

        SceneManager.LoadScene("game");



  
    }

}
    /*======================================-Code for when confirm is pressed-===================================*/





