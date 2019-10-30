using Assets.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScreenChange : MonoBehaviour
{


    /*++++++++++++++Place Holder Class++++++++++++++*/
   // public string targetScene = "game";
    public void ChangeScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);

    }

    /*--------------Place Holder Class-------------*/

    public void newCharacter() {


       
            ChangeScene("creation");
             
          
        
             

        //  GameManager.instance.DatabaseServices.Connection.Delete(userManager.CurrentCharacter);
   
       


    }


    public void loadCharacter() {


       // if (userManager.CurrentCharacter != null) {

            ChangeScene("game");


      //  }



    }


    public void loadGame() {

        
            persist.Load();
     
        SceneManager.LoadScene("game");


    }


}
