using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// This will responsible for the fading in/ out animation when switching scene
// As well as handle the data to move from which scene , so that we can display super correctly
// It also needs to handle in ensure that the player loading the correct one when 
public class SceneTranstion : MonoBehaviour
{
    [SerializeField] public Animator animator;

    public void SceneMoving(string sceneName)
    {
        // Save the data into the playerprefs if they're not returning to the mainMenu
        if ((sceneName != "MainMenu"))
        {
            // print("Current");
            PlayerPrefs.SetString("PreviousRoom", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetString("CurrentRoom", sceneName);
        }
        LoadingLevel(sceneName);
    }

    public void LoadingLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    public void MainMenuMoving()
    {
        // Check player previous location and current location
        // If not empty than we move them to the last position known when player left , so they can continue the game
        if (PlayerPrefs.HasKey("PreviousRoom") && PlayerPrefs.HasKey("CurrentRoom"))
        {
            string currentPosition = PlayerPrefs.GetString("CurrentRoom");
            StartCoroutine(LoadLevel(currentPosition));
        }
        else
        {
            // Else it's empty than load a new game
            // As well as set the playerpref in the gameData
            SceneMoving("StartingRoomNew");
        }
    }

    IEnumerator LoadLevel(string sceneName)
    {
        animator.SetTrigger("Start");
        Time.timeScale = 1;
        yield return new WaitForSeconds(1f);
        GameData.GameStatus.isMoving = true;
        SceneManager.LoadSceneAsync(sceneName);
    }
}

