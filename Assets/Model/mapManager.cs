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
        private static sqlMapGrid firstSpace;
        private static sqlMapGrid secondSpace;
        // internal static sqlMyMap CurrentMap { get => currentMap; set => currentMap = value; }

        public static void makeNewMap(int pCharacterID)
        {


            List<sqlMyMap> lcMyMap = GameManager.instance.DatabaseServices.Connection.Table<sqlMyMap>().Where(
                x => x.characterID == pCharacterID).ToList<sqlMyMap>();

            firstSpace = new sqlMapGrid
            {
                mapID = pCharacterID,
                sceneName = "Master's Room",
                xPosition = 3,
                yPosition = 1,

            };


            secondSpace = new sqlMapGrid
            {
                mapID = pCharacterID,
                sceneName = "Glowing Pool",
                xPosition = 3,
                yPosition = 2,

            };

            bool result = lcMyMap.Count > 0;
            if (!result)
            {

                var lcNewMap = new sqlMyMap
                {
                    characterID = pCharacterID,


                };
                GameManager.instance.DatabaseServices.Connection.Insert(lcNewMap);
                currentMap = lcNewMap;

               
                GameManager.instance.DatabaseServices.Connection.Insert(firstSpace);
                GameManager.instance.DatabaseServices.Connection.Insert(secondSpace);

            }
            else
            {
                currentMap = lcMyMap.FirstOrDefault();


                List<sqlMapGrid> lcMyGrid = GameManager.instance.DatabaseServices.Connection.Table<sqlMapGrid>().Where(
                x => x.mapID == currentMap.mapID).ToList<sqlMapGrid>();


                lcMyGrid.ForEach(grid => grid.mapID = currentMap.mapID);
                List<sqlMapGrid> space1 = lcMyGrid.Where(grid => grid.xPosition == 3 && grid.yPosition == 1).ToList();
                bool space1Exist = lcMyGrid.Count > 0;
                if (!space1Exist)
                {
                    GameManager.instance.DatabaseServices.Connection.Insert(firstSpace);

                }


                List<sqlMapGrid> space2 = lcMyGrid.Where(grid => grid.xPosition == 3 && grid.yPosition == 2).ToList();
                bool space2Exist = lcMyGrid.Count > 0;
                if (!space2Exist)
                {
                    GameManager.instance.DatabaseServices.Connection.Insert(secondSpace);

                }


                /*
               sqlMapGrid space1 = lcMyGrid.Where(grid => grid.xPosition == 3 && grid.yPosition == 1).FirstOrDefault();
               sqlMapGrid space2 = lcMyGrid.Where(grid => grid.xPosition == 3 && grid.yPosition == 2).FirstOrDefault();
                space1.mapID = currentMap.mapID;
                space1.sceneName = "Master's Room";
                space2.mapID = currentMap.mapID;
                space2.sceneName = "Glowing Pool";
                */




            }

           
        


          

            currentX = 3;
            currentY = 1;
        }

        public static void loadMap()
        {
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
           // Debug.Log(lcCurrentMap.FirstOrDefault().sceneName);
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

                sqlMapGrid lcSouthScene = lcCurrentMap.Where(x => x.xPosition == currentX && x.yPosition == currentY + 1).FirstOrDefault();

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

                sqlMapGrid lcNorthScene = lcCurrentMap.Where(x => x.xPosition == currentX && x.yPosition == currentY - 1).FirstOrDefault();


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


    


    






