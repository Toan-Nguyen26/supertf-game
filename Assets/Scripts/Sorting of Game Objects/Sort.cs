
using UnityEngine;

// Main menu will take care of all buttons behaviour 
public class Sort : MonoBehaviour
{
    SpriteRenderer sprite;

    RectTransform superRectTransform;

    // The supertf gameObject of the game
    [SerializeField] GameObject supertf;

    [SerializeField] float pos_y;

    // The default layer that it should be
    [SerializeField] string default_layer;

    // The new layer if super happen to be at a specific layer
    [SerializeField] string new_layer;

    float last_super_y = float.NegativeInfinity;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        superRectTransform = supertf.GetComponent<RectTransform>();
    }

    void Update()
    {
        // If super y cord is larger than the object y cord
        // We changed the sorting layer
        // else return back to the default;
        float supertf_y = superRectTransform.anchoredPosition.y;
        if (supertf_y != last_super_y)
        {
            if (supertf_y >= pos_y) sprite.sortingLayerName = new_layer;
            else sprite.sortingLayerName = default_layer;
        }

    }
}