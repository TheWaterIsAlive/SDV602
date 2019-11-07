using SQLite4Unity3d;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Model.SQL
{

    /*
     * Store an SQL exivalant to the origional scene class
     * Scene Name is used as primary key.
     * Screne Description is what is displayed when in a sence
     * adjasentText TO give a preview of next scene
     * obstricalFrame is to inprove grammar when obstricals are introduced
     * 
     */
    class sqlScenes
    {

        [PrimaryKey]
        public string sceneName { get; set; }

        public string sceneDiscription { get; set; }
        public string adjasentText { get; set; }
        public string obstricalFrame { get; set; }

    }
}
