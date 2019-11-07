using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene
{
    /*===OutDated====*/

    /*=======================================+Scene Attributes+=============================================*/
    private string _story;
    private string _adjacentText;
    private command _sceneCommand;
    private string _obstacleOne;
    private string _obstacleTwo;
    private string _north = "Empty";
    private string _east = "Empty";
    private string _south = "Empty";
    private string _west = "Empty";
    private string _sceneType = "area";
    /*=======================================-Scene Attributes-=============================================*/



    /*=======================================+Public Accessers+=============================================*/
    public command SceneCommand { get => _sceneCommand; set => _sceneCommand = value; }
    public string Story { get => _story; set => _story = value; }
   
    //public string AdjacentText { get => _adjacentText; set => _adjacentText = value; }
    public string ObstacleOne { get => _obstacleOne; set => _obstacleOne = value; }
    public string ObstacleTwo { get => _obstacleTwo; set => _obstacleTwo = value; }
    public string North { get => _north; set => _north = value; }
    public string East { get => _east; set => _east = value; }
    public string South { get => _south; set => _south = value; }
    public string West { get => _west; set => _west = value; }
    public string SceneType { get => _sceneType; set => _sceneType = value; }

    /*=======================================-Public Accessers-=============================================*/

    /*=======================================+Sets attributes on creation+=============================================*/
    public scene(string pStory, string pAdjacent)
    {

        _story = pStory;
        _adjacentText = pAdjacent;


    }
    /*=======================================-Sets attributes on creation-=============================================*/

    /*=======================================+Creates string with all scene information+=============================================*/
    public string fullScene
    {
        get => _story
            + elementManager.allScenes[_north].nextRoom(_north, "To the north")
            + elementManager.allScenes[_east].nextRoom(_east, "To the east")
            + elementManager.allScenes[_west].nextRoom(_west, "To the west")
            + elementManager.allScenes[_south].nextRoom(_south, "To the south");
    }

    /*=======================================-Creates string with all scene information-=============================================*/
  

    public void removeObstacle() {



    }

    public string nextRoom(string pRoomName, string pDirection) {

        if (pRoomName != "Empty")
        {
            return " " + pDirection + " " + _adjacentText;

        }
        else
        {

            return "";
        }


    }



}
