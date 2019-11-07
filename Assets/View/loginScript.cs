using Assets.Model;
using UnityEngine;
using UnityEngine.UI;

public class loginScript : MonoBehaviour
{
    /*
     * 
     * Connects to approprate feilds to Create a user or login
     * 
     * 
     * 
     */
    public InputField username;
    public InputField password;


    public void newAccount() {
        
            userManager.RegisterPlayer(username.text, password.text);
        

    }

    public void logIn()
    {

        userManager.LogIn(username.text, password.text);

    }

}


