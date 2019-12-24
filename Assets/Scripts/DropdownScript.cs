using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class DropdownScript : MonoBehaviour
{
    public Dropdown dropdown;
    public Skill MySkill;

    public SkillManagerScript Manager;
    public Image ImageContainer;

    public Sprite SkillImageNull;
    public Sprite SkillImageDamage;
    public Sprite SkillImageCost;
    public Sprite SkillImageStun;
    public Sprite SkillImagePoison;
    public Sprite SkillImageCritical;

    public List<Text> ListInfoText;
    
    public delegate void Icon(Sprite sprite, Text SkillName, int DropdownValue);
    public static event Icon ChangeIconOnMainCanvas;

    public void Awake()
    {
        ListInfoText[0].text = "AP Cost : " + MySkill.APCost;
        ListInfoText[1].text = "Damage : " + MySkill.Damage;
        ListInfoText[2].enabled = false;
    }
    
    public void OnValueChanged()
    {
        Debug.Log(dropdown.transform.GetChild(0).GetComponent<Text>().text);
        switch (dropdown.value)
        {
            case 0:
                ImageContainer.sprite = SkillImageNull;
                MySkill.SkillModifierIcon = SkillImageNull;

                MySkill.Damage = MySkill.DefaultDamage;
                MySkill.APCost = MySkill.DefaultAPCost;
                MySkill.StunProc = MySkill.DefaultStunProc;
                MySkill.PoisonProc = MySkill.DefaultPoisonProc;
                MySkill.CritProc = MySkill.DefaultCritProc;
                ListInfoText[0].text = "AP Cost : " + MySkill.APCost;
                ListInfoText[1].text = "Damage : " + MySkill.Damage;
                ListInfoText[2].enabled = false;
                break;
            case 1:
                ImageContainer.sprite = SkillImageDamage;
                MySkill.SkillModifierIcon = SkillImageDamage;
                //ChangeIconOnMainCanvas(SkillImageDamage, SkillName, dropdown.value);
                MySkill.Damage *= MySkill.DMG_Modifier;
                //default
                MySkill.APCost = MySkill.DefaultAPCost;
                MySkill.StunProc = MySkill.DefaultStunProc;
                MySkill.PoisonProc = MySkill.DefaultPoisonProc;
                MySkill.CritProc = MySkill.DefaultCritProc;

                ListInfoText[0].text = "AP Cost : " + MySkill.APCost;
                ListInfoText[1].text = "Damage : " + MySkill.Damage;
                ListInfoText[2].enabled = false;
                break;
            case 2:
                ImageContainer.sprite = SkillImageCost;
                MySkill.SkillModifierIcon = SkillImageCost;
                //ChangeIconOnMainCanvas(SkillImageCost, SkillName, dropdown.value);
                MySkill.APCost *= MySkill.Cost_Modifier;
                //default
                MySkill.Damage = MySkill.DefaultDamage;                
                MySkill.StunProc = MySkill.DefaultStunProc;
                MySkill.PoisonProc = MySkill.DefaultPoisonProc;
                MySkill.CritProc = MySkill.DefaultCritProc;

                ListInfoText[0].text = "AP Cost : " + MySkill.APCost;
                ListInfoText[1].text = "Damage : " + MySkill.Damage;
                ListInfoText[2].enabled = false;
                break;
            case 3:
                ImageContainer.sprite = SkillImageStun;
                MySkill.SkillModifierIcon = SkillImageStun;
                //ChangeIconOnMainCanvas(SkillImageStun, SkillName, dropdown.value);
                MySkill.StunProc = MySkill.Stun_Proc_Modifier;
                //default
                MySkill.Damage = MySkill.DefaultDamage;
                MySkill.APCost = MySkill.DefaultAPCost;
                MySkill.PoisonProc = MySkill.DefaultPoisonProc;
                MySkill.CritProc = MySkill.DefaultCritProc;

                ListInfoText[0].text = "AP Cost : " + MySkill.APCost;
                ListInfoText[1].text = "Damage : " + MySkill.Damage;
                ListInfoText[2].enabled = true;
                ListInfoText[2].text = "Stun Chance : " + MySkill.StunProc * 100f +" %";
                break;
            case 4:
                ImageContainer.sprite = SkillImagePoison;
                MySkill.SkillModifierIcon = SkillImagePoison;
                //ChangeIconOnMainCanvas(SkillImagePoison, SkillName, dropdown.value);
                MySkill.PoisonProc = MySkill.Poison_Proc_Modifier;
                //default
                MySkill.Damage = MySkill.DefaultDamage;
                MySkill.APCost = MySkill.DefaultAPCost;
                MySkill.StunProc = MySkill.DefaultStunProc;
                MySkill.CritProc = MySkill.DefaultCritProc;

                ListInfoText[0].text = "AP Cost : " + MySkill.APCost;
                ListInfoText[1].text = "Damage : " + MySkill.Damage;
                ListInfoText[2].enabled = true;
                ListInfoText[2].text = "Poison Chance : " + MySkill.PoisonProc * 100f + " %";
                break;
            case 5:
                ImageContainer.sprite = SkillImageCritical;
                MySkill.SkillModifierIcon = SkillImageCritical;
                //ChangeIconOnMainCanvas(SkillImageCritical, SkillName, dropdown.value);
                MySkill.CritProc = MySkill.Crit_Proc_Modifier;
                //default
                MySkill.Damage = MySkill.DefaultDamage;
                MySkill.APCost = MySkill.DefaultAPCost;
                MySkill.StunProc = MySkill.DefaultStunProc;
                MySkill.PoisonProc = MySkill.DefaultPoisonProc;

                ListInfoText[0].text = "AP Cost : " + MySkill.APCost;
                ListInfoText[1].text = "Damage : " + MySkill.Damage;
                ListInfoText[2].enabled = true;
                ListInfoText[2].text = "Crit Chance : " + MySkill.CritProc * 100f + " %";
                break;
        }                
        Manager.UpdateAllSlot();
    }
}
