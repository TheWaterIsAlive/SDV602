using Assets.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.View
{
    class showCharacter : MonoBehaviour
    {

        public Text outputName = default;// Creates a attribute to hold an output.



        void Start()
        {
          
            outputName.text = characterManager.Character.ToString();



        }



    }
}
