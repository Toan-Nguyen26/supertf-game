using UnityEngine;

public class SpriteSwitchTextBoxManager : IsKeyBoxManager
{
    [SerializeField] GameObject keyGameOject;
    [SerializeField] Sprite new_sprite;
    protected override void inTheEndShitChecking()
    {
        keyGameOject.GetComponent<SpriteRenderer>().sprite = new_sprite;
    }

}
