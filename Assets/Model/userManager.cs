using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Assets.Model
{
    public static class userManager
    {
        /*================================+ Varables +=================================*/
       private static user _currentUser;
   

        public static user CurrentUser { get => _currentUser; set => _currentUser = value; }
        /*================================- Varables -=================================*/

     /*===========================+Create New User+======================*/
        public static void RegisterPlayer(string pUserName, string pPassword)
        {

            /*
             * Get Relenvent People from the database.
             * Check that the user doesn't already exist.
             * Check both a password and Username were entered.
             * Create and add to database new user.
             * Move to log in.
             * 
             */

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

        /*===========================-Create New User-======================*/
        /*===========================+Log In+======================*/
        public static void LogIn(string pUserName, string pPassword)
        {

            List<user> lcUsers = GameManager.instance.DatabaseServices.Connection.Table<user>().Where<user>(
                               x => x.Username == pUserName && x.Password == pPassword
                          ).ToList<user>();

            bool result = lcUsers.Count > 0;
            if (!result)
            {
                _currentUser = null;
             
            }

            else
            {

          
                _currentUser = lcUsers.First<user>();
                SceneManager.LoadScene("main");
            }

        }
        /*===========================-Log In-======================*/

    }
}
