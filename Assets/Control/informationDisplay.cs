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
    /*
    public InputField inputMight;
    public InputField inputEndurance;
    public InputField inputFinesse;
    public InputField inputMind;
    public InputField inputSoul;
    public Text inputSkillPoints;
    */
    public Dropdown inputAlignment;
    public Dropdown inputBoon;
    public Dropdown inputFear;
    public Dropdown inputWeakness;
    public Dropdown inputVice;
    /*======================================-Connects to screen inputs-===================================*/
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
         * Makes playerCharacter a new character.
         * Sets the elements of new character to that of what has been entered.
         * Loads the next scene.
         */

        /*
        GameManager.instance.gameModel.playerCharacter = new character();
        GameManager.instance.gameModel.playerCharacter.Name = inputName.text;
        SceneManager.LoadScene("game");
        */
        //   List<sqlCharacter> lcCharacter = GameManager.instance.DatabaseServices.Connection.Table<sqlCharacter>().Where<sqlCharacter>(
        //                        x => x.playerName == userManager.CurrentUser.Username
        //                 ).ToList<sqlCharacter>();
        /*
         *   characterName = inputName.text,
                      health = 100,
                      spellPoints = 7,
                      alignment = inputAlignment.options[inputAlignment.value].text,
                      boon = inputBoon.options[inputBoon.value].text,
                      fear = inputFear.options[inputFear.value].text,
                      weakness = inputWeakness.options[inputWeakness.value].text,
                      vice = inputVice.options[inputVice.value].text,
                      playerName = userManager.CurrentUser.Username,
         * */


       
        characterManager.createCharacter(inputName.text,
            inputBoon.options[inputBoon.value].text,
            inputAlignment.options[inputAlignment.value].text,
            inputFear.options[inputFear.value].text,
            inputWeakness.options[inputWeakness.value].text,
            inputVice.options[inputVice.value].text);


        SceneManager.LoadScene("game");



        /*
       characterManager.createCharacter("Allan",
           "Allan",
           "Allan",
           "Allan",
          "Allan",
           "Allan");
         */
    }

}
    /*======================================-Code for when confirm is pressed-===================================*/





