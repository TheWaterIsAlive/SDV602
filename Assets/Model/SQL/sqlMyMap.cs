using SQLite4Unity3d;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Model.SQL
{
   public class sqlMyMap
    {


        [PrimaryKey, AutoIncrement]
        public int mapID { get; set; }
        [NotNull]
        public String characterID { get; set; }

        public int gridID { get; set; }






    }
}
