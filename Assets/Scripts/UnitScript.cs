using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public string UnitName;
    public int MaxHP;
    public int CurrentHP;

    public int UnitDamage;

    public bool TakeDamage(int DMG)
    {
        CurrentHP -= DMG;
        if(CurrentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
