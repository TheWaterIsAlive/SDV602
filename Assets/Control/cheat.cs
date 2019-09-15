using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cheat : MonoBehaviour
{
    public InputField input;
    InputField.SubmitEvent submitEvent;

    public Text output;

    /*=====================+Sets up current text interface+========================*/
    void Start()
    {
        input = this.GetComponent<InputField>();
        submitEvent = new InputField.SubmitEvent();
        submitEvent.AddListener(submitInput);
        if (input != null)
        {
            input.onEndEdit = submitEvent;
        }
    }
    /*=====================-Sets up current text interface-========================*/


    /*=====================+Code for when a command is entered+========================*/
    private void submitInput(string submittedInput)
    {
        string _currentText = output.text;

        if (submittedInput == "killmode")
        {
            output.text = "Blood from a stone";
            elementManager.allScenes["Glowing Pool"].South = "Master's Room";

        }

        else if (submittedInput == "howDoYouTurnThisOn") {
            output.text = "Nice Car";
            elementManager.allScenes["Stone Guard"].South = "A Blue Car sits. It Throws stones at you.";

        }

        input.text = "";
        input.ActivateInputField();
    }
    /*=====================-Code for when a command is entered-========================*/



    /*=====================+Code for when the input is changed+========================*/
    private void ChangeInput(string submittedInput)
    {
        Debug.Log(submittedInput);
    }

    /*=====================-Code for when the input is changed-========================*/
}
