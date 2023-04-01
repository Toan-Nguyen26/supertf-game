using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameData;
using System;
using TMPro;

// This code handle all the details of a 
public class TextBoxContentController : MonoBehaviour
{
    //Sound Effect to play the text noise
    [SerializeField] AudioSource textSoundEffect;

    // Ending soundEffect for the game
    [SerializeField] AudioSource textEndSoundEffect;
    // The TextBox CHaracter name

    [SerializeField] TextMeshProUGUI titleTMP;

    [SerializeField] TextMeshProUGUI bodyTMP;
    // The Image of our code
    private Image portrait;


    // Delay between word in the conversation
    private float letterDelay = .015f;

    void Awake()
    {
        // Get portrait of the gameObject here
        portrait = transform.GetChild(0).GetComponent<Image>();
    }


    // This code handle the logic while running the textBox
    public void runningTextBox(int character, string[,] textVariables, int currentLine)
    {
        //Start displaying the title
        titleTMP.text = textVariables[currentLine, 1];

        GameDataPotrait characterDataPotrait = GameData.GameData.Instance.gameDataPotraits[character];

        // Next we get the character portrait from the GameData corresponding to the character we just found
        List<Sprite> characterPotrait = characterDataPotrait.character_sprites;

        float sprite_x = characterDataPotrait.sprite_x;

        float sprite_y = characterDataPotrait.sprite_y;

        // Get the expressions in the corresponding textVariables
        string expression = textVariables[currentLine, 3];

        // The pick the expression and display it to the user
        PickingExpression(expression, characterPotrait, sprite_x, sprite_y);
    }

    // Pick the expression that we got from the file 
    // Then display it accoring to
    void PickingExpression(string expression, List<Sprite> characterPotrait, float sprite_x, float sprite_y)
    {
        if (characterPotrait.Count == 0)
        {
            print("Empty List , please recheck it");
            return;
        }

        foreach (Sprite s in characterPotrait)
        {
            if (expression == s.name)
            {
                transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(sprite_x, sprite_y);
                portrait.sprite = s;
                break;
            }
        }
    }

    public void updateSoundEffectVolume()
    {
        textSoundEffect.volume = PlayerPrefs.GetFloat("soundEffectVolume", .35f);

        textEndSoundEffect.volume = PlayerPrefs.GetFloat("soundEffectVolume", .35f);
    }

    // This code responsible for handling the Text Animation that took place
    public IEnumerator AnimateText(string strComplete)
    {
        int totalCharacter = strComplete.Length;
        int counter = 0;
        bodyTMP.text = strComplete;
        GameData.GameStatus.IsAnimating = true;
        textSoundEffect.Play();
        while (counter <= strComplete.Length && GameData.GameStatus.IsAnimating)
        {
            int visibleCount = counter % (totalCharacter + 1);
            bodyTMP.maxVisibleCharacters = visibleCount;
            counter++;
            yield return new WaitForSeconds(letterDelay);
        }
        textSoundEffect.Stop();
        textEndSoundEffect.Play();
        GameData.GameStatus.IsAnimating = false;
    }

}