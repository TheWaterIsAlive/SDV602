using Assets.Model.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Model
{
    public static class mapManager
    {

        /*==================================+ Varables +=========================*/
        public static sqlMyMap currentMap;
        public static int currentX;
        public static int currentY;
        /*==================================- Varables -=========================*/

        /*==================================+ Makes New Map +=========================*/
        public static void makeNewMap()
        {

            var lcNewMap = new sqlMyMap
            {
                characterID = characterManager.Character.characterName,
                gridID = (GameManager.instance.DatabaseServices.Connection.Table<sqlMapGrid>(
                       ).ToList<sqlMapGrid>().Count()) + 1

            };


            GameManager.instance.DatabaseServices.Connection.Insert(lcNewMap);
            currentMap = lcNewMap;
            /*
             * mapID what this space belongs too
             * scene name what is in the space
             * X and Y possition is where the space is located on the map
             * 
             * 
             */

            var lcFirstSpace = new sqlMapGrid
            {
                mapID = currentMap.mapID,
                sceneName = "Master's Room",
                xPosition = 3,
                yPosition = 1,

            };
            GameManager.instance.DatabaseServices.Connection.Insert(lcFirstSpace);

            var lcSecondSpace = new sqlMapGrid
            {
                mapID = currentMap.mapID,
                sceneName = "Glowing Pool",
                xPosition = 3,
                yPosition = 2,

            };
            GameManager.instance.DatabaseServices.Connection.Insert(lcSecondSpace);

            var lcThirdSpace = new sqlMapGrid
            {
                mapID = currentMap.mapID,
                sceneName = "Fancy House",
                xPosition = 2,
                yPosition = 2,

            };
            GameManager.instance.DatabaseServices.Connection.Insert(lcThirdSpace);
            var lcForthSpace = new sqlMapGrid
            {
                mapID = currentMap.mapID,
                sceneName = "Big Tree",
                xPosition = 3,
                yPosition = 3,

            };
            GameManager.instance.DatabaseServices.Connection.Insert(lcForthSpace);

            currentX = 3;
            currentY = 1;
        }
        /*==================================- Makes New Map -=========================*/

        /*=================================+ Property Of the Text Displayed in the game +======================*/
        public static string SqlStory { get => currentStory(); }

        /*=================================- Property Of the Text Displayed in the game -======================*/

        /*=================================+ Get and Add all data +======================*/

            /*
             * Gets current map
             * Gets main text
             * Gets norther text
             * Gets southern text
             * Gets eastern text
             * Gets western text
             * Add text together
             */
        private static string currentStory()
        {
            List<sqlMapGrid> lcCurrentMap = getCurrentMap();

            string lcCurrentText = findCurrent(lcCurrentMap);
            Debug.Log(lcCurrentText);

            string lcNorthText = findNorth(lcCurrentMap);
            Debug.Log(lcNorthText);

            string lcSouthText = findSouth(lcCurrentMap);
            Debug.Log(lcSouthText);

            string lcEastText = findEast(lcCurrentMap);
            Debug.Log(lcEastText);

            string lcWestText = findWest(lcCurrentMap);
            Debug.Log(lcWestText);

            return addText(lcCurrentText, lcNorthText, lcEastText, lcSouthText, lcWestText);
        }
        /*=================================- Get and Add all data -======================*/

        /*======================+Gets current map+===========================*/
        public static List<sqlMapGrid> getCurrentMap()
        {
            List<sqlMapGrid> lcCurrentMap = GameManager.instance.DatabaseServices.Connection.Table<sqlMapGrid>().Where(
                x => x.mapID == currentMap.mapID).ToList<sqlMapGrid>();
            Debug.Log(lcCurrentMap.FirstOrDefault().sceneName);
            return lcCurrentMap;
        }
        /*======================-Gets current map-===========================*/

        /*======================+Text for current space+===========================*/
        public static string findCurrent(List<sqlMapGrid> lcCurrentMap)
        {
            sqlMapGrid lcCurrentScene = lcCurrentMap.Where(grid => grid.xPosition == currentX && grid.yPosition == currentY).FirstOrDefault();

            String lcCurrentText = GameManager.instance.DatabaseServices.Connection.Table<sqlScenes>().Where(
                        x => x.sceneName == lcCurrentScene.sceneName
                        ).ToList<sqlScenes>().FirstOrDefault<sqlScenes>().sceneDiscription;
            return lcCurrentText;
        }
        /*======================-Text for current space-===========================*/
        /*======================+Text for West space+===========================*/
        public static string findWest(List<sqlMapGrid> lcCurrentMap)
        {

          try{

                sqlMapGrid lcWestScene = lcCurrentMap.Where(x => x.xPosition == currentX - 1 && x.yPosition == currentY).FirstOrDefault();

                String lcWestText = GameManager.instance.DatabaseServices.Connection.Table<sqlScenes>().Where(
                        x => x.sceneName == lcWestScene.sceneName
                        ).ToList<sqlScenes>().FirstOrDefault<sqlScenes>().adjasentText;
                return lcWestText;
            }
            catch {

                return "empty";

            }
        }
        /*======================-Text for West space-===========================*/

        /*======================+Text for East space+===========================*/
        public static string findEast(List<sqlMapGrid> lcCurrentMap)
        {

           try
            {
                sqlMapGrid lcEastScene = lcCurrentMap.Where(x => x.xPosition == currentX + 1 && x.yPosition == currentY).FirstOrDefault();

                String lcEastText = GameManager.instance.DatabaseServices.Connection.Table<sqlScenes>().Where(
                        x => x.sceneName == lcEastScene.sceneName
                        ).ToList<sqlScenes>().FirstOrDefault<sqlScenes>().adjasentText;
                return lcEastText;
            }
            catch
            {

                return "empty";

            }



        }
        /*======================-Text for East space-===========================*/


        /*======================+Text for South space+===========================*/
        public static string findSouth(List<sqlMapGrid> lcCurrentMap)
        {

            try
            {

                sqlMapGrid lcSouthScene = lcCurrentMap.Where(x => x.xPosition == currentX && x.yPosition == currentY - 1).FirstOrDefault();

                String lcSouthText = GameManager.instance.DatabaseServices.Connection.Table<sqlScenes>().Where(
                        x => x.sceneName == lcSouthScene.sceneName
                        ).ToList<sqlScenes>().FirstOrDefault<sqlScenes>().adjasentText;
                return lcSouthText;
            }
            catch
            {

                return "empty";

            }
        }
        /*======================-Text for South space-===========================*/


        /*======================+Text for North space+===========================*/
        public static string findNorth(List<sqlMapGrid> lcCurrentMap)
        {

            try
            {

                sqlMapGrid lcNorthScene = lcCurrentMap.Where(x => x.xPosition == currentX && x.yPosition == currentY + 1).FirstOrDefault();


                String lcNorthText = GameManager.instance.DatabaseServices.Connection.Table<sqlScenes>().Where(
                        x => x.sceneName == lcNorthScene.sceneName
                        ).ToList<sqlScenes>().FirstOrDefault<sqlScenes>().adjasentText;
                return lcNorthText;
            }

            catch
            {
                return "empty";
            }

            
        }
        /*======================-Text for North space-===========================*/


        /*======================+Adds only relanvent text+===========================*/
        /*
         * For each piece of text passed to this check if it is "empty",
         * if it is don't add it to the return value.
         * 
         * 
         * 
         */
        private static string addText(string pCurrentText,
            string pNorthText,
            string pEastText,
            string pSouthText,
            string pWestText) {

            string lcFullText = pCurrentText;

            if (pNorthText != "empty") {
                lcFullText = lcFullText + " To the north " + pNorthText;

            }

            if (pEastText != "empty")
            {
                lcFullText = lcFullText + " To the east " + pEastText;

            }

            if (pSouthText != "empty")
            {
                lcFullText = lcFullText + " To the south " + pSouthText;

            }

            if (pWestText != "empty")
            {
                lcFullText = lcFullText + " To the west " + pWestText;

            }



            return lcFullText;

        }
        /*======================-Adds only relanvent text-===========================*/


    }



}


    


    






