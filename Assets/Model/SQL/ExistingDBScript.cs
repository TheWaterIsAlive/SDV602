using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ExistingDBScript : MonoBehaviour {

	public Text DebugText;

	// Use this for initialization
	void Start () {
		var ds = new DataService ("handsOfTheMaster.db");
		//ds.CreateDB ();
		var users = ds.GetUser ();
		ToConsole (users);

		users = ds.GetUsersNamedRoberto ();
		ToConsole("Searching for Roberto ...");
		ToConsole (users);

		ds.CreateUser ("Test", "Test");
		ToConsole("New User has been created");
		/*var p = ds.GetJohnny ();
		ToConsole(p.ToString());
        */

	}
	
	private void ToConsole(IEnumerable<user> users){
		foreach (var user in users) {
			ToConsole(user.ToString());
		}
	}

	private void ToConsole(string msg){
		DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}

}
