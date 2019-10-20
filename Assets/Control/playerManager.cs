using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    private DataService Db = (gameModel.currentScene != null) ? GameModel.Story.DB : new DataService("ZUp.db"); // Not good because this has already happened in StoryManager???
    private Player _currentPlayer;
    private int _logInAttempts = 0;
    public bool LoggedIn = false;

    public Player CurrentPlayer
    {
        get
        {
            return _currentPlayer;
        }
    }
    public int LoginAttempts
    {
        get
        {
            return _logInAttempts;
        }
    }

    /*
     * Going to Register when ?
     * LogIn fails, ...?
     * Show Register when there are no players?
     */
    public bool PlayerExists(string pUserName)
    {
        return
                (Db.Connection.Table<Player>().Where<Player>(
                          x => x.Name == pUserName
                     ).ToList<Player>().Count > 0);
    }
    public bool RegisterPlayer(string pUserName, string pPassword)
    {
        bool result = false;
        /*
         * Need to check if the player already exists before we register
         * Then Log this player in 
         * if it fails then we don't have a registration
         */
        if (!PlayerExists(pUserName))
        {

            Player newPlayer = new Player
            {
                Name = pUserName,
                Password = pPassword,
                CurrentScene = GameModel.Story.FirstScene.Id
            };

            Db.Connection.Insert(newPlayer);

            result = LogIn(pUserName, pPassword);
        }

        return result;
    }



    /*
    * Log in
    * Set ups currentPlayer if it is sucessfull too
    */
    public bool LogIn(string pUserName, string pPassword)
    {
        List<Player> lcPlayers = Db.Connection.Table<Player>().Where<Player>(
                            x => x.Name == pUserName && x.Password == pPassword
                       ).ToList<Player>();

        bool result = lcPlayers.Count > 0;
        if (!result)
        {
            _logInAttempts++;

            _currentPlayer = null; // CurrentPlayer
        }
        else
        {
            _logInAttempts = 0;
            _currentPlayer = lcPlayers.First<Player>(); // CurrentPlayer

        }

        LoggedIn = result;

        return result;
    }
}
