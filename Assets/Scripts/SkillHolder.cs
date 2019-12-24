using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    public List<Skill> AllSkill;
    public List<Skill> ChosenSkills;
    
    public void Start()
    {
        DontDestroyOnLoad(transform);
    }

    public void CopySkill(List<Skill> AllSkill)
    {
        this.AllSkill = AllSkill;
        for (int i = 0; i < AllSkill.Count; i++)
        {
            if(AllSkill[i].IsSelected)
            {
                ChosenSkills.Add(AllSkill[i]);
            }
        }
    }
}
