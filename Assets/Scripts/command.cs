
//using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class command : MonoBehaviour
{

    protected command next;
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

public class MoveCommand : command
{

    public MoveCommand(string pAdverb)
    {
        adverb = pAdverb;
    }



    public override void perform(string[] pSplitCommand)
    {
        Debug.Log("Moving" + adverb);
        splitCommand = pSplitCommand;
        scene lcScene = GameManager.instance.gameModel.currentScene;

        switch (adverb)
        {
            case "north":
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.North != "Empty")
                    if (lcScene.SceneType == "area")
                    {
                        GameManager.instance.gameModel.currentScene = elementManger.allScenes[lcScene.North];
                    }
                break;
            case "south":
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.South != "Empty")
                    if (lcScene.SceneType == "area")
                    {
                        GameManager.instance.gameModel.currentScene = elementManger.allScenes[lcScene.South];
                    }
                break;
            case "west":
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.West != "Empty")
                    if (lcScene.SceneType == "area")
                    {
                        GameManager.instance.gameModel.currentScene = elementManger.allScenes[lcScene.West];
                    }
                break;
            case "east":
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.East != "Empty")
                    if (lcScene.SceneType == "area")
                    {
                        GameManager.instance.gameModel.currentScene = elementManger.allScenes[lcScene.East];
                    }
                break;

        }

    }
}

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
       


    }
}

public class AttackCommand : command
{

    public AttackCommand(string pAdverb)
    {
        adverb = pAdverb;
    }



    public override void perform(string[] pSplitCommand)
    {
        Debug.Log("Opening" + adverb + " menu");
        splitCommand = pSplitCommand;
        scene lcScene = GameManager.instance.gameModel.currentScene;


        switch (adverb)
        {
            case "north":
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.North != "Empty")
                    if (lcScene.SceneType == "obsticale")
                    {
                        GameManager.instance.gameModel.currentScene.North = elementManger.allScenes[lcScene.North].North;
                    }
                break;
            case "south":
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.South != "Empty")
                    if (lcScene.SceneType == "obsticale")
                    {
                        GameManager.instance.gameModel.currentScene.South = elementManger.allScenes[lcScene.South].South;
                    }
                break;
            case "west":
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.West != "Empty")
                    if (lcScene.SceneType == "obsticale")
                    {
                        GameManager.instance.gameModel.currentScene.West = elementManger.allScenes[lcScene.West].West;
                    }
                break;
            case "east":
                lcScene = GameManager.instance.gameModel.currentScene;
                if (lcScene.East != "Empty")
                    if (lcScene.SceneType == "obsticale")
                    {
                        GameManager.instance.gameModel.currentScene.East = elementManger.allScenes[lcScene.East].East;
                    }
                break;

        }


    }




}
public class SpeakCommand : command
{

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




}


public class BuyCommand : command
{

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




}

