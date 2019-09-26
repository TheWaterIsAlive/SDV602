using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class character
{
    /*=======================================+Character Elements+=============================================*/
    private string _name;
    /*
    private Dictionary<string, int> _attributes = new Dictionary<string, int>();
    private Dictionary<string, trait> _traits = new Dictionary<string, trait>();
    private Dictionary<string, item> _items = new Dictionary<string, item>();
    private Dictionary<string, spell> _spells = new Dictionary<string, spell>();
    */
   // private int _hands = 0; 
    private int _health = 100;
    /*=======================================-Character Elements-=============================================*/


    /*=======================================+Public Accessers+=============================================*/
    public string Name { get => _name; set => _name = value; }

    /*=======================================-Public Accessers-=============================================*/


    /*=======================================+Creates New Character+=============================================*/

    public static void createCharacter(string pName) {

        gameModel.playerCharacter = new character();
        gameModel.playerCharacter.Name = pName;


    }
    /*=======================================-Creates New Character-=============================================*/


    /*=======================================+Character takes damage+=============================================*/

    public void takeDamage(int pDamage) {

        _health = _health - pDamage;


    }

    /*=======================================-Character takes damage-=============================================*/

}
