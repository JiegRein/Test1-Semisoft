using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public string SkillName;
    public float Damage;
    public float APCost;
    public float StunProc;
    public float PoisonProc;
    public float CritProc;
    public float PoisonDamage;
    public float CritMultiplier;

    public Button SkillButton;
    public Text SkillStatusText;
    public Sprite SkillModifierIcon;
    public bool IsSelected;
    public int SPUsed;

    public float DMG_Modifier; //use 0 to 1
    public float Cost_Modifier; //use 0 to 1
    public float Stun_Proc_Modifier; //use 0 to 1
    public float Poison_Proc_Modifier; //use 0 to 1
    public float Crit_Proc_Modifier; //use 0 to 1

    [HideInInspector]
    public float DefaultDamage;
    [HideInInspector]
    public float DefaultAPCost;
    [HideInInspector]
    public float DefaultStunProc;
    [HideInInspector]
    public float DefaultPoisonProc;
    [HideInInspector]
    public float DefaultCritProc;
    public void Awake()
    {
        DefaultDamage = Damage;
        DefaultAPCost = APCost;
        DefaultStunProc = StunProc;
        DefaultPoisonProc = PoisonProc;
        DefaultCritProc = CritProc;
    }
}
