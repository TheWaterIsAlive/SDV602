using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateDBScript : MonoBehaviour {

	public Text DebugText;

	// Use this for initialization
	void Start () {
		StartSync();
	}

    private void StartSync()
    {
        var ds = new DataService("handsOfTheMaster.db");
      //  ds.CreateDB();
        
        var users = ds.GetUser ();
        ToConsole (users);
        users = ds.GetUsersNamedRoberto ();
        ToConsole("Searching for Roberto ...");
        ToConsole (users); 
    }
	
	private void ToConsole(IEnumerable<user> users){
		foreach (var person in users) {
			ToConsole(person.ToString());
		}
	}
	
	private void ToConsole(string msg){
		DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}
}
