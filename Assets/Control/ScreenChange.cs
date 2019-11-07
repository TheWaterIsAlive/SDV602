using UnityEngine;
using UnityEngine.SceneManagement;
public class ScreenChange : MonoBehaviour
{
    /*==============================+Parse Sceen Name to change scene+=============================*/
    public void ChangeScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);

    }

    /*==============================-Parse Sceen Name to change scene-=============================*/


    /*==============================+Moves to the character creation screen+=============================*/
    public void newCharacter() {

            ChangeScene("creation");
        
    }
    /*==============================-Moves to the character creation screen-=============================*/
    /*
     * 
     * 
     * 
     * 
     * 
     * 
     * Future Code To load characters and maps.
    public void loadCharacter() {


 
        characterManager.Character = GameManager.instance.DatabaseServices.Connection.Table<sqlCharacter>().Where(
            x => x.playerName == userManager.CurrentUser.Username).FirstOrDefault();


        mapManager.currentMap = GameManager.instance.DatabaseServices.Connection.Table<sqlMyMap>().Where(x
            => x.characterID == characterManager.Character.characterName).FirstOrDefault();


            ChangeScene("game");


      //  }



    }
    */
    /*==============================+Old Game load Funtion+=============================*/
    public void loadGame() {

        
            persist.Load();
     
        SceneManager.LoadScene("game");


    }

    /*==============================-Old Game load Funtion-=============================*/
}
