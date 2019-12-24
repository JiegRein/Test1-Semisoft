using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsScript : MonoBehaviour
{
    public Skill MySkill;
    private SkillManagerScript SkillManager;
    private PlayerUnit Player;

    private Button SkillButton;
    private Text SkillStatusText; //equiped / unequiped
    private Sprite SkillModifierIcon;
    public Image Icon;
    
    public void Init(Skill mySkill, SkillManagerScript skillManager, PlayerUnit player)
    {
        Debug.Log("INIT SLOT");
        MySkill = mySkill;
        SkillManager = skillManager;
        Player = player;

        SkillButton = GetComponent<Button>();
        SkillStatusText = transform.GetChild(0).GetComponent<Text>();
        SkillModifierIcon = transform.GetChild(1).GetComponent<Sprite>();

        UpdateUI();
    }

    public void UpdateUI()
    {
        SkillButton = MySkill.SkillButton;
        SkillStatusText = MySkill.SkillStatusText;
        SkillModifierIcon = MySkill.SkillModifierIcon;
        Icon.sprite = SkillModifierIcon;

        if (Player.SP >= MySkill.SPUsed)
        {
            if (MySkill.IsSelected)
            {
                Debug.Log("Skill Equiped");
                SkillStatusText.text = "Equiped";
            }
            else
            {
                Debug.Log("Skill Unequiped");
                SkillStatusText.text = "Unequiped";
                SkillStatusText.color = Color.red;
                SkillManager.SkillCounter.text = Player.SP + " / 4 Skill can be chosen";
            }
        }
    }

    public void OnClickButton()
    {
        Debug.Log("On Click");
        if(Player.SP >= MySkill.SPUsed && !MySkill.IsSelected)
        {
            MySkill.IsSelected = true;
            SkillManager.UpdateAllSlot();
            Player.SP -= 1;
            SkillStatusText.color = Color.green;
            SkillManager.SkillCounter.text = Player.SP + " / 4 Skill can be chosen";
            Debug.Log("Player SP : " + Player.SP);            
        }
        else if (MySkill.IsSelected)
        {
            MySkill.IsSelected = false;
            Player.SP += 1;
            SkillManager.UpdateAllSlot();
            Debug.Log("Player SP : " + Player.SP);
        }
    }
}
