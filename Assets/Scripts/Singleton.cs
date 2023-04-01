using UnityEngine;

public class Singleton : MonoBehaviour
{
    // This field can be accesed through our singleton instance,
    // but it can't be set in the inspector, because we use lazy instantiation
    // set it to true to enable players  pressing the keyboard
    // false otherwise
    public bool keyboardPress = true;

    // Static singleton instance
    public static Singleton Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void enableKeyboardPress (bool state)
    {      
        keyboardPress = state;
    }

}