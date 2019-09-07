using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.View
{
    class showCharacter : MonoBehaviour
    {

        public Text outputName;// Creates a attribute to hold an output.



        void Start()
        {

            outputName.text = GameManager.instance.gameModel.playerCharacter.Name;// Connects output to outputName



        }



    }
}
