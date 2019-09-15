using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScreenChange : MonoBehaviour
{


    /*++++++++++++++Place Holder Class++++++++++++++*/
    public string targetScene = "game";
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);

    }

    /*--------------Place Holder Class-------------*/


    public void loadGame() {

        if (persist.control != null)
        {
            persist.control.Load();
        }
        SceneManager.LoadScene("game");


    }


}
