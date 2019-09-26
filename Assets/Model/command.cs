
//using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class command : MonoBehaviour
{

    //protected command next;
    protected string adverb;
    protected string[] splitCommand;
    // Use this for initialization
    void Awake()
    {

    }

    public virtual void perform(string[] splitCommand)
    {
    }


}


/*=======================================+Move Command+=============================================*/
public class MoveCommand : command
{

    public MoveCommand(string pAdverb)
    {
        adverb = pAdverb;
    }



    public override void perform(string[] pSplitCommand)
    {
        /* +Loads required varables+ */
        Debug.Log("Moving" + adverb);
        splitCommand = pSplitCommand;
        scene lcScene = gameModel.currentScene;
        /* -Loads required varables- */

                 /*
                  * 
                  * Switch statement for the four game directions.
                  * The game loads the current scene.
                  * The game wont proceed if the target scene is an Empty scene and an area.
                  * Changes currentScene to the approprate scene.
                  * 
                  */


        switch (adverb)
        {

            /* +Code for move north+ */
            case "north":
                lcScene = gameModel.currentScene;
                if (lcScene.North != "Empty" && lcScene.SceneType == "area")
    
                   
                        gameModel.currentScene = elementManager.allScenes[lcScene.North];
                   
                break;

            /* -Code for move north- */
            /* +Code for move south+ */
            case "south":
                lcScene = gameModel.currentScene;
                if (lcScene.South != "Empty" && lcScene.SceneType == "area")
                   
                        gameModel.currentScene = elementManager.allScenes[lcScene.South];
                    
                break;
            /* -Code for move south- */
            /* +Code for move west+ */
            case "west":
                lcScene = gameModel.currentScene;
                if (lcScene.West != "Empty" && lcScene.SceneType == "area")
                    
                        gameModel.currentScene = elementManager.allScenes[lcScene.West];
                    
                break;
            /* -Code for move west- */
            /* +Code for move east+ */
            case "east":
                lcScene = gameModel.currentScene;
                if (lcScene.East != "Empty" && lcScene.SceneType == "area")
                  
                        gameModel.currentScene = elementManager.allScenes[lcScene.East];
                
                break;
                /* -Code for move east- */

        }

    }
}
/*=======================================-Move Command-=============================================*/
/*=======================================+Menu Command+=============================================*/
public class MenuCommand : command
{

    public MenuCommand(string pAdverb)
    {
        adverb = pAdverb;
    }



    public override void perform(string[] pSplitCommand)
    {
        Debug.Log("Opening" + adverb + " menu");
        splitCommand = pSplitCommand;


        switch (adverb)
        {
            case "spell":


                SceneManager.LoadScene("spell");

                break;

            case "character":


                SceneManager.LoadScene("sheet");

                break;

            case "save":

                if (persist.control != null) { 
                persist.control.Save();
                }
                break;
        }





    }

}
    /*=======================================-Menu Command-=============================================*/

    /*=======================================+Attack Command+=============================================*/
    public class AttackCommand : command
    {

        public AttackCommand(string pAdverb)
        {
            adverb = pAdverb;
        }


        public override void perform(string[] pSplitCommand)
        {

            /* +Loads required varables+ */
            Debug.Log("Attacking" + adverb);
            splitCommand = pSplitCommand;
            scene lcScene = gameModel.currentScene; //Gains a copy of the current scene for local use
            /* -Loads required varables- */

        /*
         * 
         * Switch statement for the four game directions.
         * The game loads the current scene.
         * The game wont proceed if the target scene is an Empty scene
         * Set lcScene to the target space  and contiune if it is an obstacle.
         * Removes the obstacle from between the current scene and the next screen.
         * Set current scene to current scenes with updated information.
         * 
         */




        switch (adverb)
            {
                /* +Code for attack north+ */
                case "north":
                    lcScene = gameModel.currentScene;
                    if (lcScene.North != "Empty")
                    lcScene = elementManager.allScenes[gameModel.currentScene.North];
                if (lcScene.SceneType == "obstacle")
                        {
                    ///gameModel.currentScene.North = elementManager.allScenes[lcScene.North].North;
                    elementManager.allScenes[lcScene.South].North = lcScene.North;
                    gameModel.currentScene = elementManager.allScenes[lcScene.North];
                }
                    break;
                /* -Code for attack north- */
                /* +Code for attack south+ */
                case "south":
                    lcScene = gameModel.currentScene;
                    if (lcScene.South != "Empty")

                    lcScene = elementManager.allScenes[gameModel.currentScene.South];

                         if (lcScene.SceneType == "obstacle")
                        {

                         
                        //gameModel.currentScene.North = elementManager.allScenes[lcScene.North].North;
                        elementManager.allScenes[lcScene.North].South = lcScene.South;
                        gameModel.currentScene = elementManager.allScenes[lcScene.North];
                    }
                    break;
                /* -Code for attack south- */
                /* +Code for attack west+ */
                case "west":
                    lcScene = gameModel.currentScene;
                    if (lcScene.West != "Empty")

                    lcScene = elementManager.allScenes[gameModel.currentScene.West];
                if (lcScene.SceneType == "obstacle")
                        {
                    // gameModel.currentScene.West = elementManager.allScenes[lcScene.West].West;

                    elementManager.allScenes[lcScene.East].West = lcScene.West;
                    gameModel.currentScene = elementManager.allScenes[lcScene.East];


                }
                    break;
                /* -Code for attack west- */
                /* +Code for attack east+ */
                case "east":
                    lcScene = gameModel.currentScene;
                    if (lcScene.East != "Empty")
                    lcScene = elementManager.allScenes[gameModel.currentScene.East];
                if (lcScene.SceneType == "obstacle")
                        {
                    // gameModel.currentScene.East = elementManager.allScenes[lcScene.East].East;

                    elementManager.allScenes[lcScene.West].East = lcScene.East;
                    gameModel.currentScene = elementManager.allScenes[lcScene.West];

                }
                    break;
                    /* -Code for attack east- */
            }


        }




    }

    /*=======================================-Attack Command-=============================================*/
    /*=======================================+Speak Command+=============================================*/
    public class SpeakCommand : command
    {
        /*+++++++Not funtional+++++++*/

        public SpeakCommand(string pAdverb)
        {
            adverb = pAdverb;
        }



        public override void perform(string[] pSplitCommand)
        {
            Debug.Log("Opening" + adverb + " menu");
            splitCommand = pSplitCommand;
            scene _Scene = gameModel.currentScene;


        }


        /*--------Not funtional--------*/

    }


    /*=======================================-Speak Command-=============================================*/

    /*=======================================+Buy Command+=============================================*/
    public class BuyCommand : command
    {
        /*+++++++Not funtional+++++++*/

        public BuyCommand(string pAdverb)
        {
            adverb = pAdverb;
        }



        public override void perform(string[] pSplitCommand)
        {
            Debug.Log("Opening" + adverb + " menu");
            splitCommand = pSplitCommand;
            scene _Scene = gameModel.currentScene;


        }



        /*--------Not funtional--------*/
    }

        /*=======================================-Buy Command-=============================================*/
                                                                                                             