using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUDScript : MonoBehaviour
{
    public Text NameText;
    public Text HPText;
    public Text APText;

    public void SetUI(PlayerUnit unit, int CurrentHP, int CurrentAP)
    {
        NameText.text = unit.UnitName;
        HPText.text = "HP = " +CurrentHP + " / " + unit.MaxHP;
        APText.text = "AP = " +CurrentAP + " / " + unit.MaxAP;

    }
    public void SetUI(UnitScript unit, int CurrentHP)
    {
        NameText.text = unit.UnitName;
        HPText.text = "HP = " + CurrentHP + " / " + unit.MaxHP;
    }
}
