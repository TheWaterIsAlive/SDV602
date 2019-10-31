using Assets.Model.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Model
{
    public static class mapManager
    {
       private static sqlMyMap currentMap;
      ///  public static int[] currentLocation = new int[2];

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
            

        }
    }
}


    


    






