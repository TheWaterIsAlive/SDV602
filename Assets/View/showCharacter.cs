using Assets.Model;
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

        public Text outputName = default;// Creates a attribute to hold an output.



        void Start()
        {
            /*
                if (outputName.text != null && GameManager.instance.gameModel.playerCharacter.Name != null)
                {
                    outputName.text = GameManager.instance.gameModel.playerCharacter.Name;// Connects output to outputName
                }
                */
            outputName.text = characterManager.Character.ToString();



        }



    }
}
