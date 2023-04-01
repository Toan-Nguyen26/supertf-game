using UnityEngine;

// This script will player at the beginning of each time player start a new game
public class OutOfHallway : MonoBehaviour
{

    [SerializeField] GameObject FirstTimeTextBox;


    [SerializeField] string firstTimeKey;

    // Start is called before the first frame update
    // If it's the first time than PlayerPref it so it doesn't happen again
    // If super got transfer to the next word , we  play SecondTimeTextBox
    void Start()
    {
        if (!PlayerPrefs.HasKey(firstTimeKey)) FirstTimeAppear(firstTimeKey, FirstTimeTextBox);
        // If super was dragged into an alternative reality , we triggered a different scene

    }

    void FirstTimeAppear(string newKey, GameObject textToAppear)
    {
        StopGameStatus();
        textToAppear.SetActive(true);
        PlayerPrefs.SetString(newKey, "InANewAreathat'snotBedroomorGoro");
    }

    void StopGameStatus()
    {
        GameData.GameStatus.isMoving = false;
        GameData.GameStatus.enableKeyPress = false;
    }

}
