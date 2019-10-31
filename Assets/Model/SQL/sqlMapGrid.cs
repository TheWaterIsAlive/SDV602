using SQLite4Unity3d;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Model.SQL
{
   public class sqlMapGrid
    {


        [PrimaryKey, AutoIncrement]
        public int spaceID { get; set; }
        [NotNull]
        public int mapID { get; set; }
        public string sceneName { get; set; }
        public int xPosition { get; set; }

        public int yPosition { get; set; }



    }
}
