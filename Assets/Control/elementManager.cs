
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class elementManager
{

    /* 
     * This class Stores static dictonaries of 
     * all of the game elements to keep consistancy
     * between different Screens.
     * NO LONGER IN USE
     * Was used to store object before SQL was implemented.
     * 
     * In the Future this could be used to pre-load aspects of the game
     */


    /*=======================================+Element Dictonaies+=============================================*/
    public static Dictionary<string, trait> _allTraits = new Dictionary<string, trait>();
    public static Dictionary<string, item> _allItems = new Dictionary<string, item>();
    public static Dictionary<string, spell> _allSpells = new Dictionary<string, spell>();
    public static Dictionary<string, scene> allScenes = new Dictionary<string, scene>();
    public static Dictionary<string, scene> _activeScenes = new Dictionary<string, scene>();
    /*=======================================-Element Dictonaies-=============================================*/



    /*==============================+Display a list of a dictonary's content+==============================*/
    public static string printAll()
    {

        return "not done";


    }
    /*================================-Display a list of a dictonary's content-==============================*/

}
