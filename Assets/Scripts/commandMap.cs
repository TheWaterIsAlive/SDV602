
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commandMap : MonoBehaviour
{

    private Dictionary<string, command> Commands;

    private string _result = "";

    // Use this for initialization
    public commandMap()
    {
        Commands = new Dictionary<string, command>();
        Commands.Add("go north", new MoveCommand("north"));
        Commands.Add("go south", new MoveCommand("south"));
        Commands.Add("go east", new MoveCommand("east"));
        Commands.Add("go west", new MoveCommand("west"));
        Commands.Add("attack north", new MoveCommand("north"));
        Commands.Add("attack west", new MoveCommand("west"));
        Commands.Add("attack south", new MoveCommand("south"));
        Commands.Add("attack east", new MoveCommand("east"));
        Commands.Add("menu spell", new MenuCommand("spell"));


    }

    public string Result { get => _result; set => _result = value; }

    public bool runCommand(string pFormatedCommand, string[] pAryCommandParts)
    {
        bool lcResult = false;
        command lcCommand;


        if (Commands.ContainsKey(pFormatedCommand))
        {
            lcCommand = Commands[pFormatedCommand];
            lcCommand.perform(pAryCommandParts);
            lcResult = true;

            Result = GameManager.instance.gameModel.currentScene.fullScene;




        }
        else
        {
            Debug.Log("I do not understand");
            Result = GameManager.instance.gameModel.currentScene.fullScene;
            lcResult = false;
        }


        return lcResult;
    }
}

