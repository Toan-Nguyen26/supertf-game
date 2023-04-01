using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;
// To do list with the Inventory Tab Text Box and such
public class KeyboardController : MonoBehaviour
{
    // For the PauseGameTextBox
    [SerializeField] GameObject PauseGameTextBox;

    // For the PauseGameTextBox
    [SerializeField] GameObject InstructionTextBox;


    // List of all disabled layer tha will take place
    [SerializeField] public List<GameObject> layerDisable;

    // A boolean use only for checking if the ReturnGameMenu appear or not
    private bool appear { get; set; } = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("NewGame"))
        {
            appear = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if esc is press then stop player movement as well as button click clack
        if (Input.GetKeyDown(KeyCode.Escape)
        && (!InstructionTextBox.activeInHierarchy)
        && (GameData.GameStatus.enableKeyPress == true)
        && !Input.GetMouseButtonDown(0))
        {
            // If it's already appear then return to the game if the user decided to
            // resume all player movements and clicks
            if (appear)
            {
                SetGameStatus("NotPauseMenu", false, PauseGameTextBox);


            }
            // Otherwise , disable all player movements and clicks
            // And make the ReturnMenu appear
            else
            {
                SetGameStatus("Ignore Raycast", true, PauseGameTextBox);
            }
        }

        // If tab pressed then show the instructions , as long as the pasue game is not pressent at the time
        if (Input.GetKeyDown(KeyCode.Tab)
        && (!PauseGameTextBox.activeInHierarchy)
        && (GameData.GameStatus.enableKeyPress == true)
        && !Input.GetMouseButtonDown(0))
        {
            if (appear)
            {
                SetGameStatus("NotPauseMenu", false, InstructionTextBox);
            }
            // Otherwise , disable all player movements and clicks
            // And make the ReturnMenu appear
            else
            {
                SetGameStatus("Ignore Raycast", true, InstructionTextBox);
            }

        }
    }

    private void SetGameStatus(string layername, bool status, GameObject textBox)
    {
        SetLayer(layername);
        textBox.SetActive(status);
        appear = status;
        GameData.GameStatus.isMoving = !status;
        // Time.timeScale = status ? 0 : 1;
    }

    // SetLayer function will handle all the dirty stuff when it comes to disable stuff
    // This will disba
    public void SetLayer(string layername)
    {
        foreach (GameObject element in layerDisable)
        {
            element.layer = LayerMask.NameToLayer(layername);
        }
    }


}
