
//using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameModel
{
    
    public scene currentScene;
    public string sceneCode = "Masters Room";
    

    private void makeStory()
    {
        elementManger.allScenes.Add(
            "Masters Room",
            new scene(
                "You enter a drab room. On an old dusty crate sits" +
                " an old man wearing a mangy rob which draps ofhis " +
                "arm highlighting the fact that this man doesn't have any hands" +
                ". This is the man you know to be The Master. What do you do?",
                "is a swirling portal."));

        elementManger.allScenes.Add(
            "Glowing Pool",
            new scene(
                "You enter into a large cavern with crystaline walls." +
                " The fantest gleam of light manages to shim thought the tarnised crystals surfices. " +
                "A large pillar rises from the centre of the room, on which sits a smiling imp. " +
                "A pool of glowing liquard sits to the west. What do you do?",
                "a glass surfice covered in strange mist"));


        elementManger.allScenes.Add(
           "Empty",
           new scene("You Should not be here",
               "The world stretchs infinately in this direction"
               ));

        elementManger.allScenes.Add(
            "Stone Guard",
            new scene(
                "No! Banned!",
                "A Stonegaurd stands"));



        elementManger.allScenes["Stone Guard"].SceneType = "obsticale";
        elementManger.allScenes["Masters Room"].North = "Glowing Pool";
        elementManger.allScenes["Glowing Pool"].South = "Stone Guard";
        elementManger.allScenes["Stone Guard"].South = "Masters Room";

        // firstScene = "Masters Room";
        //firstScene = new Area("You enter a drab room. A mirror full of swelling energy sits at your back.On an old dusty crate sits an old man wearing a mangy rob which draps ofhis arm highlighting the fact that this man doesn't have any hands. This is the man you know to be The Master.What do you do? ");
        //firstScene.North = "Glowing Pool";
        //firstScene.North.South = firstScene;

        currentScene = elementManger.allScenes[sceneCode];
    }
    public gameModel()
    {
        makeStory();
    }
}
