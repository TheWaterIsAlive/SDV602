using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{

    private string _name;
    private string _discription;
    private string _sceneEffect;
    private int _cost;





    public static spell createSpell() {

    spell test = new spell();


    return test;

    }


    public bool castSpell() {

        return false;

    }
}
