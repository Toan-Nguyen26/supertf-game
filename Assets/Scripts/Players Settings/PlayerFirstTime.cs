using UnityEngine;

// This script will player at the beginning of each time player start a new game
public class PlayerFirstTime : MonoBehaviour
{
    [SerializeField] GameObject Instructions;

    [SerializeField] GameObject FirstTimeTextBox;

    [SerializeField] GameObject SecondTimeTextBox;


    [SerializeField] GameObject supertf;

    // Start is called before the first frame update
    // If it's the first time than PlayerPref it so it doesn't happen again
    // If super got transfer to the next word , we  play SecondTimeTextBox
    void Start()
    {
        if (!PlayerPrefs.HasKey("NewGame"))
        {
            supertf.GetComponent<KeyboardController>().SetLayer("Ignore Raycast");
            GameData.GameStatus.isMoving = false;
            Instructions.SetActive(true);
        }
        // If super was dragged into an alternative reality , we triggered a different scene

        else if (PlayerPrefs.HasKey("NewReality"))
        {
            SecondTimeTextBox.SetActive(true);
            PlayerPrefs.DeleteKey("NewReality");
        }

    }

    void Update()
    {
        if (!Instructions.activeInHierarchy && !PlayerPrefs.HasKey("NewGame"))
        {
            FirstTimeTextBox.SetActive(true);
            PlayerPrefs.SetString("NewGame", "Firsttime");
            Destroy(this.gameObject);
        }

    }

    void StopGameStatus()
    {
        GameData.GameStatus.isMoving = false;
        GameData.GameStatus.enableKeyPress = false;
    }

}
