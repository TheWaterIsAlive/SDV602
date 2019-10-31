using Assets.Model.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Model
{
    public static class mapManager
    {
        public static sqlMyMap currentMap;
        public static int currentX;
        public static int currentY;

        // internal static sqlMyMap CurrentMap { get => currentMap; set => currentMap = value; }

        public static void makeNewMap()
        {





            var lcNewMap = new sqlMyMap
            {
                characterID = characterManager.Character.Id,
                gridID = (GameManager.instance.DatabaseServices.Connection.Table<sqlMapGrid>(
                       ).ToList<sqlMapGrid>().Count()) + 1

            };


            GameManager.instance.DatabaseServices.Connection.Insert(lcNewMap);
            currentMap = lcNewMap;


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

            currentX = 3;
            currentY = 1;
        }



        public static string SqlStory { get => currentStory(); }


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

        public static List<sqlMapGrid> getCurrentMap()
        {
            List<sqlMapGrid> lcCurrentMap = GameManager.instance.DatabaseServices.Connection.Table<sqlMapGrid>().Where(
                x => x.mapID == currentMap.mapID).ToList<sqlMapGrid>();
            Debug.Log(lcCurrentMap.FirstOrDefault().sceneName);
            return lcCurrentMap;
        }

       
        public static string findCurrent(List<sqlMapGrid> lcCurrentMap)
        {
            sqlMapGrid lcCurrentScene = lcCurrentMap.Where(grid => grid.xPosition == currentX && grid.yPosition == currentY).FirstOrDefault();

            String lcCurrentText = GameManager.instance.DatabaseServices.Connection.Table<sqlScenes>().Where(
                        x => x.sceneName == lcCurrentScene.sceneName
                        ).ToList<sqlScenes>().FirstOrDefault<sqlScenes>().sceneDiscription;
            return lcCurrentText;
        }

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



}


  
}


    


    






