using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class textInput : MonoBehaviour
{
    InputField input;
    InputField.SubmitEvent submitEvent;

    public Text output;
    //public string commandType = "game";

    // Use this for initialization


    /*=====================+Sets up current text interface+========================*/
    void Start()
    {
        input = this.GetComponent<InputField>();
        submitEvent = new InputField.SubmitEvent();
        submitEvent.AddListener(submitInput);
        input.onEndEdit = submitEvent;
        if (output != null)
        {
            output.text = gameModel.currentScene.fullScene;
        }
    }
    /*=====================-Sets up current text interface-========================*/


    /*=====================+Code for when a command is entered+========================*/
    private void submitInput(string submittedInput)
    {
         //string _currentText = output.text;
    
        commandProcessor _commandProcessor = new commandProcessor();
        if (output != null)
        {
            output.text = _commandProcessor.parseCommand(submittedInput);
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
