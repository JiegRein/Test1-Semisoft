using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoHUDScript : MonoBehaviour
{
    public Text InfoText;

    public void SetInfoText(string text)
    {
        InfoText.text = text;
    }
}
