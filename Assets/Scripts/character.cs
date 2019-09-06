using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character
{

    private string _name;
    private Dictionary<string, int> _attributes = new Dictionary<string, int>();
    private Dictionary<string, trait> _traits = new Dictionary<string, trait>();
    private Dictionary<string, item> _items = new Dictionary<string, item>();
    private Dictionary<string, spell> _spell = new Dictionary<string, spell>();
   // private int _hands = 0;
    private int _health = 100;



    public static void createCharacter() {





    }


    public void takeDamage(int pDamage) {

        _health = _health - pDamage;


    }



}
