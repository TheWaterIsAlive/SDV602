using Assets.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginScript : MonoBehaviour
{

    public InputField username;
    public InputField password;
    //InputField.SubmitEvent submitEvent;

    // Start is called before the first frame update
    void Start()
    {
       // username = this.GetComponent<InputField>();
       // password = this.GetComponent<InputField>();

    }

    // Update is called once per frame





    public void newAccount() {

        //GameManager.databaseServices.CreateUser(username.text, password.text);
        
            userManager.RegisterPlayer(username.text, password.text);
        

    }

    public void logIn()
    {

        userManager.LogIn(username.text, password.text);

    }

}


