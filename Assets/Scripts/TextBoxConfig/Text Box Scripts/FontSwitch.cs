using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FontSwitch : MonoBehaviour
{
    [SerializeField] TMP_FontAsset owfrog_font;

    [SerializeField] TMP_FontAsset owfrog_title_font;

    [SerializeField] TMP_FontAsset default_font;

    [SerializeField] TMP_FontAsset default_title_font;

    [SerializeField] TextMeshProUGUI titleTMP;

    [SerializeField] TextMeshProUGUI bodyTMP;

    // Update is called once per frame
    void Update()
    {
        if (titleTMP.text == "OWFROG")
        {
            titleTMP.font = owfrog_title_font;
            bodyTMP.font = owfrog_font;
        }
        else
        {
            titleTMP.font = default_title_font;
            bodyTMP.font = default_font;
        }
    }
}
