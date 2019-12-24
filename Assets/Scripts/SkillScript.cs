using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class SkillScript : MonoBehaviour
{

    public Skill MySkill;
    public Image icon;
    public Text Skill;
    
    public void ChangeIcon(Sprite sprite, Text SkillName, int DropDownValue)
    {
        if(Skill.text == SkillName.text)
        {
            MySkill.SkillModifierIcon = sprite;
        }
    }
}
/*
            switch (DropDownValue)
            {
                case 1:
                    Debug.Log("Skill Script 1");
                    MySkill.Damage = MySkill.Damage * MySkill.DMG_Modifier;
                    MySkill.APCost = 1f;
                    MySkill.Stun_Proc_Modifier = 0f;
                    MySkill.Poison_Proc_Modifier = 0f;
                    MySkill.Crit_Proc_Modifier = 0f;
                    break;
                case 2:
                    Debug.Log("Skill Script 2");
                    MySkill.Damage = 1f;
                    MySkill.APCost = MySkill.APCost * MySkill.Cost_Modifier;
                    MySkill.Stun_Proc_Modifier = 0f;
                    MySkill.Poison_Proc_Modifier = 0f;
                    MySkill.Crit_Proc_Modifier = 0f;
                    break;
                case 3:
                    Debug.Log("Skill Script 3");
                    MySkill.Damage = 1f;
                    MySkill.APCost = 1f;
                    MySkill.Stun_Proc_Modifier = 0.5f;
                    MySkill.Poison_Proc_Modifier = 0f;
                    MySkill.Crit_Proc_Modifier = 0f;
                    break;
                case 4:
                    Debug.Log("Skill Script 4");
                    MySkill.Damage = 1f;
                    MySkill.APCost = 1f;
                    MySkill.Stun_Proc_Modifier = 0f;
                    MySkill.Poison_Proc_Modifier = 0.5f;
                    MySkill.Crit_Proc_Modifier = 0f;
                    break;
                case 5:
                    Debug.Log("Skill Script 5");
                    MySkill.Damage = 1f;
                    MySkill.APCost = 1f;
                    MySkill.Stun_Proc_Modifier = 0f;
                    MySkill.Poison_Proc_Modifier = 0f;
                    MySkill.Crit_Proc_Modifier = 0.25f;
                    break;
            }
*/