using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameData;
using System;

// NOTE: I'm not gonna make this a child class of KeyBoardController
// IN the unity editor , it'll show variables of KeyBoard which I don't want to appear
public class TextBoxManager : MonoBehaviour
{
    // THE REQUIRED FIELD
    // We need to handle the ignore raycast - this is not the best solution I did
    [SerializeField] GameObject supertf;

    //Contain the File that we need to handle
    [SerializeField] TextAsset conversationFile;

    // THE OPTIONAL FIELD
    // A gameObject of Illutration that need to appear
    [SerializeField] GameObject illustration;

    // Early endAtLine to stop the dialog sooner , incase it's a keyItem
    [SerializeField] protected int endAtLine;

    // The expression controller of the game
    TextBoxContentController textBoxContentController;

    // An array holding the amount of textLines
    private string[] textLines;

    private string[,] textVariables;

    // Start of the conversation line , by default it's 0
    protected int currentLine = 0;

    // A boolean to ensure that the text doesn't go to the next line instantly
    private bool isWaiting = true;

    void Awake()
    {
        // Start getting the potrait , cut the data into arrays that readable , and start at the correspoinding lines
        preparingConversation();
        lineChecking();
    }

    void preparingConversation()
    {
        textBoxContentController = gameObject.GetComponent<TextBoxContentController>();

        // If not textfile is not null then split it every second
        if (conversationFile != null)
        {
            textLines = (conversationFile.text.Split('\n'));
        }

        // Get the length of the textLines and then store all the needed variables into textVariables    
        int length = textLines.Length;
        textVariables = new string[length, 4];

        // Text Variables has 4 string on each line
        // 0: determine the character to appear on the portrait
        // 1: the string to appear as the title for the conversation, it'll not always be their name of course
        // 2: the big string displaying the conversations
        // 3: the expression on the portrait, varies
        for (int i = 0; i < length; i++)
        {
            string[] variables = (textLines[i].Split(';'));
            textVariables[i, 0] = variables[0].Trim();
            textVariables[i, 1] = variables[1].Trim();
            textVariables[i, 2] = variables[2].Trim();
            textVariables[i, 3] = variables[3].Trim();
        }

        // Check if we don't set a specific amount , stop at there // Else we can just run it till the end
        if (endAtLine == 0) endAtLine = length;
    }

    // I have to do this every single time , since if this get enable , the getMouseDown get activated
    // Leads to the dialogue skip to the next line
    private void OnEnable()
    {
        // Wait for 1 seconds
        isWaiting = true;

        StartCoroutine(Waiting());

        // First we disable all the rayCase in the room
        supertf.GetComponent<KeyboardController>().SetLayer("Ignore Raycast");

        // Disable all keyPress As Well
        GameData.GameStatus.enableKeyPress = false;

        GameData.GameStatus.isMoving = false;

        StartCoroutine(textBoxContentController.AnimateText(textVariables[currentLine, 2]));
    }

    void Update()
    {
        textBoxContentController.updateSoundEffectVolume();

        // Print out the next line in the list
        if (currentLine < endAtLine)
        {
            // First we get the int matching a charcter in our gameData
            int character = Int32.Parse(textVariables[currentLine, 0]);

            switch (character)
            {
                case 10:
                    illustration.SetActive(true);
                    break;
                case 11:
                    illustration.SetActive(true);
                    closeTextBox();
                    break;
                default:
                    textBoxContentController.runningTextBox(character, textVariables, currentLine);
                    break;
            }
        }
        // Once we done witll all the text , close the box and if it's an object , set isObjectText to true 
        // to redo all again if play happened to click on it more than once
        else
        {
            closeTextBox();
        }


        if ((Input.GetMouseButtonDown(0)) && (!isWaiting) && !GameData.GameStatus.isAnimating)
        {
            currentLine += 1;

            if (currentLine < endAtLine)
            {

                if (textVariables[currentLine, 2].Length != 0) StartCoroutine(textBoxContentController.AnimateText(textVariables[currentLine, 2]));
            }

        }

    }

    // Closing the textBox
    void closeTextBox()
    {
        // First we disable the textBox
        gameObject.SetActive(false);

        // Set the current line to 0 in case it's an object
        currentLine = 0;

        // Then we allowed super to move again
        GameData.GameStatus.isMoving = true;

        // Allow all button pressing again
        GameData.GameStatus.enableKeyPress = true;

        // If it's a key then make it an object again
        lineChecking();

        inTheEndShitChecking();

        // Enable Raycast again after finishing the textbox
        supertf.GetComponent<KeyboardController>().SetLayer("NotPauseMenu");
    }


    // Need a better solution
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(.25f);
        isWaiting = false;
    }

    protected virtual void lineChecking()
    {
        return;
    }

    protected virtual void inTheEndShitChecking()
    {
        return;
    }
}