using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceSpriteManager : MonoBehaviour
{
    [SerializeField] protected Sprite old_sprite;

    [SerializeField] protected Sprite new_sprite;

    [SerializeField] protected string lockedKey;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey(lockedKey))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = new_sprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = old_sprite;
        }
    }

    protected virtual void removeCollisionController() { }
}
