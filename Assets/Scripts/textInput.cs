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
        output.text = GameManager.instance.gameModel.currentScene.fullScene;

    }
    /*=====================-Sets up current text interface-========================*/
    private void submitInput(string submitedInput)
    {
         string _currentText = output.text;
    
        commandProcessor _commandProcessor = new commandProcessor();
        output.text = _commandProcessor.parseCommand(submitedInput);
        input.text = "";
        input.ActivateInputField();
    }

    private void ChangeInput(string submitedInput)
    {
        Debug.Log(submitedInput);
    }
}
