using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Model
{
   public static class characterManager
    {
        private static sqlCharacter _character;

        public static sqlCharacter Character { get => _character; set => _character = value; }

        public static void createCharacter(string pName,
           string pAligment,
           string pBoon, 
           string pFear, 
           string pWeakness,
           string pVice) {

            /*
                        List<sqlCharacter> lcCharacter = GameManager.instance.DatabaseServices.Connection.Table<sqlCharacter>().Where<sqlCharacter>(
                      x => x.playerName == userManager.CurrentUser.Username).ToList<sqlCharacter>();


                */
            List<sqlCharacter> lcCharacter = GameManager.instance.DatabaseServices.Connection.Table<sqlCharacter>().Where(
                          x => x.playerName == userManager.CurrentUser.Username).ToList();


            bool characterExists = lcCharacter.Count() > 0;
                          
                          /*== userManager.CurrentUser.Username
                          ).ToList<sqlCharacter>().FirstOrDefault<sqlCharacter>();
                          */



            //    bool result = lcCharacter.Count > 0;
            if (!characterExists)
            {


                var lcNewCharacter = new sqlCharacter
                {
                    characterName = pName,
                    health = 100,
                    spellPoints = 7,
                    alignment = pAligment,
                    boon = pBoon,
                    fear = pFear,
                    weakness = pWeakness,
                    vice = pVice,
                    playerName = userManager.CurrentUser.Username,


                };
                GameManager.instance.DatabaseServices.Connection.Insert(lcNewCharacter);
                _character = lcNewCharacter;

               

            }
            else
            {

                lcCharacter.FirstOrDefault().characterName = pName;
                lcCharacter.FirstOrDefault().health = 100;
                lcCharacter.FirstOrDefault().spellPoints = 7;
                lcCharacter.FirstOrDefault().alignment = pAligment;
                lcCharacter.FirstOrDefault().boon = pBoon;
                lcCharacter.FirstOrDefault().fear = pFear;
                lcCharacter.FirstOrDefault().weakness = pWeakness;
                lcCharacter.FirstOrDefault().vice = pVice;
                lcCharacter.FirstOrDefault().playerName = userManager.CurrentUser.Username;
                GameManager.instance.DatabaseServices.Connection.InsertOrReplace(lcCharacter);
                // InsertOrReplace(thisCharacter);
                _character = lcCharacter.FirstOrDefault();
                // sqlCharacter thisCharacter = lcCharacter[0];


            }
            
        }



    }



    }

