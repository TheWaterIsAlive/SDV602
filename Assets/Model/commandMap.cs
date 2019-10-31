
using Assets.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commandMap
{

    /*=======================================+List of acceptable commands+=============================================*/
    private Dictionary<string, command> Commands;
    /*=======================================-List of acceptable commands-=============================================*/
    /*=======================================+Command Result String+=============================================*/
    private string _result = "";
    /*=======================================-Command Result String-=============================================*/


    /*=======================================+Initialisation code+=============================================*/
    public commandMap()
    {
                /*
                 * Adds commands which can be ran to the Commands dicrionary.
                 */
        Commands = new Dictionary<string, command>();
        Commands.Add("move north", new MoveCommand("north"));
        Commands.Add("move south", new MoveCommand("south"));
        Commands.Add("move east", new MoveCommand("east"));
        Commands.Add("move west", new MoveCommand("west"));
        Commands.Add("attack north", new AttackCommand("north"));
        Commands.Add("attack west", new AttackCommand("west"));
        Commands.Add("attack south", new AttackCommand("south"));
        Commands.Add("attack east", new AttackCommand("east"));
        Commands.Add("menu spell", new MenuCommand("spell"));
        Commands.Add("menu character", new MenuCommand("character"));
        Commands.Add("menu save", new MenuCommand("save"));


    }
    /*=======================================-Initialisation code-=============================================*/


    /*=======================================+Public Accessers+=============================================*/
    public string Result { get => _result; set => _result = value; }
    /*=======================================-Public Accessers-=============================================*/


    /*=======================================+Run Command+=============================================*/
    public bool runCommand(string pFormatedCommand, string[] pAryCommandParts)
    {
        bool lcResult = false;
        command lcCommand;


        if (Commands.ContainsKey(pFormatedCommand))
        {
            lcCommand = Commands[pFormatedCommand];
            lcCommand.perform(pAryCommandParts);
            lcResult = true;

            Result = mapManager.SqlStory;




        }
        else
        {
            Debug.Log("I do not understand");
            Result = mapManager.SqlStory;
            lcResult = false;
        }


        return lcResult;
    }
}
/*=======================================-Run Command-=============================================*/
