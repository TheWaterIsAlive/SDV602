using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Model
{
    public static class userManager
    {

       private static user _currentUser;
     //   private static sqlCharacter _currentCharacter;

        public static user CurrentUser { get => _currentUser; set => _currentUser = value; }
       // public static sqlCharacter CurrentCharacter { get => _currentCharacter; set => _currentCharacter = value; }

        public static void RegisterPlayer(string pUserName, string pPassword)
        {
            List<user> lcUsers = GameManager.instance.DatabaseServices.Connection.Table<user>().Where<user>(
                              x => x.Username == pUserName
                         ).ToList<user>();

            bool result = lcUsers.Count > 0;

            if (pUserName != "" && pPassword != "" && !result)
            {
                var lcNewUser = new user
                {
                    Username = pUserName,
                    Password = pPassword
                };
                GameManager.instance.DatabaseServices.Connection.Insert(lcNewUser);

                LogIn(pUserName, pPassword);
            }


          

        }


        public static void LogIn(string pUserName, string pPassword)
        {

            List<user> lcUsers = GameManager.instance.DatabaseServices.Connection.Table<user>().Where<user>(
                               x => x.Username == pUserName && x.Password == pPassword
                          ).ToList<user>();

            bool result = lcUsers.Count > 0;
            if (!result)
            {
                _currentUser = null;
              //  _currentCharacter = null;
            }

            else
            {

              /*  List<sqlCharacter> lcCharacter = GameManager.instance.DatabaseServices.Connection.Table<sqlCharacter>().Where<sqlCharacter>(
                             x => x.playerName == pUserName
                        ).ToList<sqlCharacter>();
                bool resultCharacter = lcUsers.Count > 0;
                if (!resultCharacter)
                {

                    _currentCharacter = null;
                }
                else {
                    _currentCharacter = lcCharacter.First<sqlCharacter>();

                }
                   */
                _currentUser = lcUsers.First<user>();
                SceneManager.LoadScene("main");
            }

        }

    }
}
