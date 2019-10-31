using SQLite4Unity3d;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Model.SQL
{
    class sqlScenes
    {

        [PrimaryKey]
        public string sceneName { get; set; }

        public string sceneDiscription { get; set; }
        public string adjasentText { get; set; }
        public string obstricalFrame { get; set; }

    }
}
