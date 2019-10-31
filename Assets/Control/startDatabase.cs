using Assets.Model.SQL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startDatabase : MonoBehaviour
{


    private DataService _databaseServices = new DataService("handsOfTheMaster.db");

  

    // Start is called before the first frame update
    void Start()
    {
            


    _databaseServices.CreateDB(new[] {
           typeof(user),
           typeof(sqlCharacter),
           typeof(sqlMyMap),
           typeof(sqlMapGrid),
           typeof(sqlScenes),

    });
        SceneManager.LoadScene("login");


    }

    // Update is called once per frame
    
}
