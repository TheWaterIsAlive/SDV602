
//using Assets.Scripts;
using Assets.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class command
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
        scene lcScene = GameManager.instance.gameModel.currentScene;

     //   mapManager.GetRetrieveCurrentMap();
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
                //lcScene = GameManager.instance.gameModel.currentScene;
                if (mapManager.findNorth(mapManager.getCurrentMap()) != "empty") {

                    mapManager.currentY = mapManager.currentY + 1;
                    Debug.Log(mapManager.findNorth(mapManager.getCurrentMap()));
                    Debug.Log(mapManager.findSouth(mapManager.getCurrentMap()));
                    Debug.Log(mapManager.findEast(mapManager.getCurrentMap()));
                    Debug.Log(mapManager.findWest(mapManager.getCurrentMap()));

                }
                    /*
                    if (lcScene.SceneType == "area")
                    {
                        GameManager.instance.gameModel.currentScene = elementManager.allScenes[lcScene.North];
                    }
                    */
                break;

            /* -Code for move north- */
            /* +Code for move south+ */
            case "south":
                /*
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.South != "Empty")
                    if (lcScene.SceneType == "area")
                    {
                        GameManager.instance.gameModel.currentScene = elementManager.allScenes[lcScene.South];
                    }
                break;
                */
                if (mapManager.findSouth(mapManager.getCurrentMap()) != "empty")
                {

                    mapManager.currentY = mapManager.currentY - 1;

                }
                break;
            /* -Code for move south- */
            /* +Code for move west+ */
            case "west":
                /*
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.West != "Empty")
                    if (lcScene.SceneType == "area")
                    {
                        GameManager.instance.gameModel.currentScene = elementManager.allScenes[lcScene.West];
                    }
                    */
                
                if (mapManager.findWest(mapManager.getCurrentMap()) != "empty")
                {

                    mapManager.currentX = mapManager.currentX - 1;

                }
                break;
            /* -Code for move west- */
            /* +Code for move east+ */
            case "east":
                /*
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.East != "Empty")
                    if (lcScene.SceneType == "area")
                    {
                        GameManager.instance.gameModel.currentScene = elementManager.allScenes[lcScene.East];
                    }
                    */
                
                if (mapManager.findEast(mapManager.getCurrentMap()) != "empty")
                {

                    mapManager.currentX = mapManager.currentX + 1;

                }
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

              
                persist.Save();
             
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
            scene lcScene = GameManager.instance.gameModel.currentScene; //Gains a copy of the current scene for local use
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
                    lcScene = GameManager.instance.gameModel.currentScene;
                    if (lcScene.North != "Empty")
                    lcScene = elementManager.allScenes[GameManager.instance.gameModel.currentScene.North];
                if (lcScene.SceneType == "obstacle")
                        {
                    ///GameManager.instance.gameModel.currentScene.North = elementManager.allScenes[lcScene.North].North;
                    elementManager.allScenes[lcScene.South].North = lcScene.North;
                    GameManager.instance.gameModel.currentScene = elementManager.allScenes[lcScene.North];
                }
                    break;
                /* -Code for attack north- */
                /* +Code for attack south+ */
                case "south":
                    lcScene = GameManager.instance.gameModel.currentScene;
                    if (lcScene.South != "Empty")

                    lcScene = elementManager.allScenes[GameManager.instance.gameModel.currentScene.South];

                         if (lcScene.SceneType == "obstacle")
                        {

                         
                        //GameManager.instance.gameModel.currentScene.North = elementManager.allScenes[lcScene.North].North;
                        elementManager.allScenes[lcScene.North].South = lcScene.South;
                        GameManager.instance.gameModel.currentScene = elementManager.allScenes[lcScene.North];
                    }
                    break;
                /* -Code for attack south- */
                /* +Code for attack west+ */
                case "west":
                    lcScene = GameManager.instance.gameModel.currentScene;
                    if (lcScene.West != "Empty")

                    lcScene = elementManager.allScenes[GameManager.instance.gameModel.currentScene.West];
                if (lcScene.SceneType == "obstacle")
                        {
                    // GameManager.instance.gameModel.currentScene.West = elementManager.allScenes[lcScene.West].West;

                    elementManager.allScenes[lcScene.East].West = lcScene.West;
                    GameManager.instance.gameModel.currentScene = elementManager.allScenes[lcScene.East];


                }
                    break;
                /* -Code for attack west- */
                /* +Code for attack east+ */
                case "east":
                    lcScene = GameManager.instance.gameModel.currentScene;
                    if (lcScene.East != "Empty")
                    lcScene = elementManager.allScenes[GameManager.instance.gameModel.currentScene.East];
                if (lcScene.SceneType == "obstacle")
                        {
                    // GameManager.instance.gameModel.currentScene.East = elementManager.allScenes[lcScene.East].East;

                    elementManager.allScenes[lcScene.West].East = lcScene.East;
                    GameManager.instance.gameModel.currentScene = elementManager.allScenes[lcScene.West];

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
            scene _Scene = GameManager.instance.gameModel.currentScene;


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
            scene _Scene = GameManager.instance.gameModel.currentScene;


        }



        /*--------Not funtional--------*/
    }

        /*=======================================-Buy Command-=============================================*/
                                                                                                             