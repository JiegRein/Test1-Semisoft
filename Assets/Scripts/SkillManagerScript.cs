using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillManagerScript : MonoBehaviour
{
    public List<Skill> AllSkills = new List<Skill>();
    public List<SlotsScript> Slots = new List<SlotsScript>();
    public PlayerUnit Player;
    public List<GameObject> SkillSlot = new List<GameObject>();
    public Text SkillCounter;
    
    public void Start()
    {
        for (int i = 0; i < AllSkills.Count; i++)
        {
            GameObject go = SkillSlot[i];

            SlotsScript slot = go.GetComponent<SlotsScript>();
            slot.Init(AllSkills[i], this, Player);

            Slots.Add(slot);
        }
    }

    public void UpdateAllSlot()
    {
        Debug.Log("Update UI");
        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i].UpdateUI();
        }
    }
    public List<Skill> GetAllSkill()
    {
        return AllSkills;
    }
}
    