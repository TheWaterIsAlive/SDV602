using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    /*=======================================+Spell Information+=============================================*/
    private string _name;
    private string _description;
    private string _sceneEffect;
    private int _cost;
    /*=======================================-Spell Information-=============================================*/



    /*=======================================+Creates New Spell+=============================================*/
    public static spell createSpell() {

    spell test = new spell();


    return test;

    }
    /*=======================================-Creates New Spell-=============================================*/

    public bool castSpell() {
        /*++++++++++++Unimplemented++++++++++++*/
        return false;
        /*------------Unimplemented------------*/
    }
}
