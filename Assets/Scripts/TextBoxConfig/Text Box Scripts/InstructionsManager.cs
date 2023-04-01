using UnityEngine;

// This script will show the instructions at the very beginning of the game , of course
public class InstructionsManager : MonoBehaviour
{
    [SerializeField] GameObject PauseTextBox;


    // Update is called once per frame
    public void OnOpenInstruction()
    {
        gameObject.SetActive(true);
        PauseTextBox.SetActive(false);
    }

    public void OnCloseIntruction()
    {
        gameObject.SetActive(false);
    }
}
