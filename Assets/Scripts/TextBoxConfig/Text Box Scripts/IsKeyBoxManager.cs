using UnityEngine;

public class IsKeyBoxManager : TextBoxManager
{

    // Check to see if the item is a key item or not
    [Header("Key")]
    [SerializeField] string playerPrefsKey;

    // Contain the int of the newCurrentLine
    [SerializeField] int newCurrentLine;

    // Contain the int of the newEndOfLine
    [SerializeField] int newEndOfLine;

    // ----------------------------------------------

    // If the key item has not been interacted with , leave it the way it's
    // Else we change the new line 
    protected override void lineChecking()
    {
        // If the GameData key is bigger or equal to what we have , then we change the currentLine and endOfLine to what we have here
        // Else we just increment the key since the keyObjects was interacted with
        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            currentLine = newCurrentLine;
            endAtLine = newEndOfLine;
        }
        else
        {
            PlayerPrefs.SetString(playerPrefsKey, " ");

            int keys = PlayerPrefs.GetInt("keys"); // Get the current keys from PlayerPrefs
            keys++; // Increase the keys by 1
            PlayerPrefs.SetInt("keys", keys);

            print("The key is: " + playerPrefsKey + " There're " + keys + " in the game");
        }
    }
}


