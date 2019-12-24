using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ModifierScript : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject ModifierCanvas;
    public SkillHolder SkillHolder;
    public SkillManagerScript Manager;
            
    public void Awake()
    {
        MainCanvas.SetActive(true);
        ModifierCanvas.SetActive(false);
    }

    public void BringUpModiferUi()
    {
        ModifierCanvas.SetActive(true);
        MainCanvas.SetActive(false);        
    }

    public void BackToMainMenu()
    {
        MainCanvas.SetActive(true);
        ModifierCanvas.SetActive(false);        
    }

    public void GameStart()
    {
        SkillHolder.CopySkill(Manager.GetAllSkill());
        Debug.Log(SkillHolder.ChosenSkills.Count);
        if (SkillHolder.ChosenSkills.Count < 4)
        {
            Manager.SkillCounter.text = "Must Choose 4 Skills";
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
