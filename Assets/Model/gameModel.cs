
//using Assets.Scripts;
using Assets.Model.SQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameModel
{
    /*=======================================+Stores Objects related to game state+=============================================*/
    public scene currentScene;
    public string sceneCode = "Master's Room";
    public character playerCharacter;
    private List<sqlScenes> defaultScenes = new List<sqlScenes>();
    /*=======================================-Stores Objects related to game state-=============================================*/


    /*=======================================+Sets up game scenes+=============================================*/
    private void makeStory()
    {


        sqlScenes mastersRoom = new sqlScenes {

          sceneName = "Master's Room",

    sceneDiscription = "You enter a drab room. On an old dusty crate sits" +
                " an old man wearing a mangy robe which drapes off his " +
                "arms, highlighting the fact that this man doesn't have any hands" +
                ". This is the man you know to be The Master. What do you do?",
    adjasentText = "is a swirling portal.",
    obstricalFrame = "stands in front of a swirling portal."


};


        
            defaultScenes.Add(mastersRoom);
        

        elementManager.allScenes.Add(
            "Master's Room",
            new scene(
                "You enter a drab room. On an old dusty crate sits" +
                " an old man wearing a mangy robe which drapes off his " +
                "arms, highlighting the fact that this man doesn't have any hands" +
                ". This is the man you know to be The Master. What do you do?",
                "is a swirling portal."));

        

        elementManager.allScenes.Add(
            "Glowing Pool",
            new scene(
                "You enter into a large cavern with crystalline walls." +
                " The faintest gleam of light manages to shimmer through the tarnished crystal surfaces. " +
                "A large pillar rises from the centre of the room, on top of which sits a smiling imp. " +
                "A pool of glowing liquid shimmers ominously to the west. What do you do?",
                "a glass surface covered in strange mist"));



        sqlScenes glowingPool = new sqlScenes
        {

            sceneName = "Glowing Pool",

            sceneDiscription = "You enter into a large cavern with crystalline walls." +
                " The faintest gleam of light manages to shimmer through the tarnished crystal surfaces. " +
                "A large pillar rises from the centre of the room, on top of which sits a smiling imp. " +
                "A pool of glowing liquid shimmers ominously to the west. What do you do?",
            adjasentText = "an aluring glow calls to you.",
            obstricalFrame = "blocks a faint glow."


        };



        defaultScenes.Add(glowingPool);


        elementManager.allScenes.Add(
           "Empty",
           new scene("You should not be here",
               "The world stretches infinitely in this direction."
               ));

        elementManager.allScenes.Add(
            "Stone Guard",
            new scene(
                "No! Banned!",
                "a Stone Guard stands."));



        elementManager.allScenes["Stone Guard"].SceneType = "obstacle";
        elementManager.allScenes["Master's Room"].North = "Glowing Pool";
        elementManager.allScenes["Glowing Pool"].South = "Stone Guard";
        elementManager.allScenes["Stone Guard"].North = "Glowing Pool";
        elementManager.allScenes["Stone Guard"].South = "Master's Room";

        // firstScene = "Masters Room";
        //firstScene = new Area("You enter a drab room. A mirror full of swelling energy sits at your back.On an old dusty crate sits an old man wearing a mangy rob which draps ofhis arm highlighting the fact that this man doesn't have any hands. This is the man you know to be The Master.What do you do? ");
        //firstScene.North = "Glowing Pool";
        //firstScene.North.South = firstScene;

        currentScene = elementManager.allScenes[sceneCode];

        GameManager.instance.DatabaseServices.Connection.InsertAll(defaultScenes);
    }


    /*=======================================-Sets up game scenes-=============================================*/

    /*=======================================+Runs makeStory on start up+=============================================*/
    public gameModel()
    {
        makeStory();
    }

    /*=======================================-Runs makeStory on start up-=============================================*/



}
