
using UnityEngine;

// Main menu will take care of all buttons behaviour 
public class MainMenu : MonoBehaviour
{
    private int levelToLoad;

    [SerializeField] GameObject StartButton;
    [SerializeField] GameObject ToolsButton;
    [SerializeField] GameObject CreditButton;
    [SerializeField] GameObject QuitButton;

    [SerializeField] GameObject DeleteSaveButton;

    [SerializeField] GameObject OnDeleteAppear;
    [SerializeField] GameObject ReturnButton;
    [SerializeField] GameObject SoundSlider;


    // Exit the game
    public void GameExit()
    {
        // This is for the build 
        Application.Quit();
    }

    // Send the user to setting option
    public void GameSetting()
    {
        MainButtonsStatus(false);
        ReturnButton.SetActive(true);
        SoundSlider.SetActive(true);
    }

    // ReturnButton to the main screen , disable return and soundSlider and enable the rest of everything 
    public void GameReturn()
    {
        MainButtonsStatus(true);
        ReturnButton.SetActive(false);
        SoundSlider.SetActive(false);
    }

    // -------------------------------------------------------------------------------------------
    // When the user want to delete the game Data , we show up the prompt to delete the game data
    public void OnEnableDelete()
    {
        MainButtonsStatus(false);
        OnDeleteAppear.SetActive(true);
    }


    public void DeleteYes()
    {
        PlayerPrefs.DeleteAll();
        DeleteNo();
    }

    // If the player chose to not delete the save game , then just return to the olde menu
    public void DeleteNo()
    {
        OnDeleteAppear.SetActive(false);
        MainButtonsStatus(true);
    }
    // --------------------------------------------------------------------


    void MainButtonsStatus(bool status)
    {
        StartButton.SetActive(status);
        ToolsButton.SetActive(status);
        CreditButton.SetActive(status);
        DeleteSaveButton.SetActive(status);
        QuitButton.SetActive(status);
    }
}
