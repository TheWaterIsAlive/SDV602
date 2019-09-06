using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene
{



    private string _story;
    private string _adjasentText;
    private command _sceneCommand;
    private string obsticalOne;
    private string obsticalTwo;
    private string _north = "Empty";
    private string _east = "Empty";
    private string _south = "Empty";
    private string _west = "Empty";
    private string _sceneType = "area";

    public command SceneCommand { get => _sceneCommand; set => _sceneCommand = value; }
    public string Story { get => _story; set => _story = value; }
   
    public string AdjasentText { get => _adjasentText; set => _adjasentText = value; }
    public string ObsticalOne { get => obsticalOne; set => obsticalOne = value; }
    public string ObsticalTwo { get => obsticalTwo; set => obsticalTwo = value; }
    public string North { get => _north; set => _north = value; }
    public string East { get => _east; set => _east = value; }
    public string South { get => _south; set => _south = value; }
    public string West { get => _west; set => _west = value; }
    public string SceneType { get => _sceneType; set => _sceneType = value; }

    public scene(string pStory, string pAdjasent)
    {

        _story = pStory;
        _adjasentText = pAdjasent;


    }

    public string fullScene
    {
        get => _story
            + " To the north " + elementManger.allScenes[_north].AdjasentText
            + "To the east " + elementManger.allScenes[_east].AdjasentText
            + "To the west " + elementManger.allScenes[_west].AdjasentText
            + "To the south " + elementManger.allScenes[_south].AdjasentText;
    }


    public bool isArea() {


        if (SceneType == "Area")
        {
            return true;

        }
        else {

            return false;
        }


    }

    


}
