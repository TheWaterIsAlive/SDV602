using System.Linq;

namespace Assets.Model
{
    /*
     * This class holds the funtionality of character.
     * As we are no longer using objects.
     * This Lets us store all of the funtionality to do with character in one place
     * 
     */
    public static class characterManager
    {
        /*=======================================+Character Elements+=============================================*/
        private static sqlCharacter _character;

        public static sqlCharacter Character { get => _character; set => _character = value; }
        /*=======================================-Character Elements-=============================================*/

        /*=======================================+Creates New Character+=============================================*/
        /*
         * 
         * Create Character takes all required inputs.
         * Gets the character from the database Where user is current user
         * If Character doesn't exist set values to default and store data.
         * Else create and store new character.
         * 
         * 
         */

        public static void createCharacter(string pName,
           string pAligment,
           string pBoon, 
           string pFear, 
           string pWeakness,
           string pVice) {

          
            sqlCharacter lcCharacter = GameManager.instance.DatabaseServices.Connection.Table<sqlCharacter>().Where(
                          x => x.playerName == userManager.CurrentUser.Username
                          ).ToList<sqlCharacter>().FirstOrDefault<sqlCharacter>();

            if (lcCharacter != null)
            {
                lcCharacter.characterName = pName;
                lcCharacter.health = 100;
                lcCharacter.spellPoints = 7;
                lcCharacter.alignment = pAligment;
                lcCharacter.boon = pBoon;
                lcCharacter.fear = pFear;
                lcCharacter.weakness = pWeakness;
                lcCharacter.vice = pVice;
                lcCharacter.playerName = userManager.CurrentUser.Username;
                GameManager.instance.DatabaseServices.Connection.InsertOrReplace(lcCharacter);
                _character = lcCharacter;

            }
            else
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
                // sqlCharacter thisCharacter = lcCharacter[0];


            }
            
        }

        /*=======================================-Character Elements-=============================================*/

    }



}

