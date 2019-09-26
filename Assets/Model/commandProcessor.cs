using System;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;
public class commandProcessor
{
    public commandProcessor()
    {
    }

    /*=======================================+Format Command and Start Command Process+=============================================*/
    public String parseCommand(String parsedCommand)
    {
        String _result = "Do not understand";

        /*========================+Formats Command+=====================*/
        parsedCommand = parsedCommand.ToLower();
        String[] splitCommand = parsedCommand.Split(' ');
        /*========================-Formats Command-=====================*/


        if (splitCommand.Length >= 2)
        {
            String _formatedCommand = splitCommand[0] + " " + splitCommand[1];
            commandMap _commandMap = new commandMap();

            
            if (_commandMap.runCommand(_formatedCommand, splitCommand))
            {
                _result = _commandMap.Result;
            }
            else
                _result = gameModel.currentScene.fullScene + "\n" + _result;

        }
        else
            _result = gameModel.currentScene.fullScene + "\n" + _result;


        return _result;

    }
}
/*=======================================-Format Command and Start Command Process-=============================================*/
