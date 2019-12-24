using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState {Start, PlayerTurn, EnemyTurn, Won, Lost, Stun, Poison}

public class BattleManager : MonoBehaviour
{
    public BattleState state;
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    public BattleHUDScript PlayerHUD;
    public BattleHUDScript EnemyHUD;

    public InfoHUDScript InfoHUD;

    public List<Text> ListSkill;
    public List<Text> APCostText;
    public List<Text> DamageText;

    PlayerUnit PlayerUnit;
    UnitScript EnemyUnit;
    GameObject newGO;
    SkillHolder NewHolder;
    Skill SkillNameUsed;
    public void Start()
    {
        Debug.Log("Start");
        newGO = GameObject.FindGameObjectWithTag("Holder") as GameObject;
        NewHolder = newGO.GetComponent<SkillHolder>();
        state = BattleState.Start;
        if (GameObject.FindGameObjectWithTag("Holder") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Holder"));
        }
        StartCoroutine(Setup());
    }
    private IEnumerator Setup()
    {
        GameObject PlayerObject = Instantiate(PlayerPrefab, new Vector3(-7, 0, 0), Quaternion.identity);
        PlayerUnit = PlayerObject.GetComponent<PlayerUnit>();
        GameObject EnemyObject = Instantiate(EnemyPrefab, new Vector3(5, 1, 0), Quaternion.identity);
        EnemyUnit = EnemyObject.GetComponent<UnitScript>();

        PlayerHUD.SetUI(PlayerUnit, PlayerUnit.MaxHP, PlayerUnit.MaxAP);
        EnemyHUD.SetUI(EnemyUnit, EnemyUnit.MaxHP);
        InfoHUD.SetInfoText("Your Fight Begins");

        PlayerUnit.PlayerSkill = NewHolder.ChosenSkills;
        SkillNameAssign();

        yield return new WaitForSeconds(2f);

        state = BattleState.PlayerTurn;
        StartCoroutine(PlayerTurn());
    }

    private IEnumerator PlayerTurn()
    {
        InfoHUD.SetInfoText("Player Turn!");
        yield return new WaitForSeconds(1f);
    }
    public void SkillButtonPressed(Button btn)  
    {
        if(state != BattleState.PlayerTurn)
        {
            return;
        }
        StartCoroutine(SkillAttack(btn.transform.GetChild(0).GetComponent<Text>().text));
    }
    private IEnumerator SkillAttack(string BtnName)
    {
        float CritHit = 1;
        bool Execute = false;
        for (int i = 0; i < PlayerUnit.PlayerSkill.Count; i++)
        {
            if (BtnName == "X")
            {
                Execute = true;
            }
            else if (PlayerUnit.AP >= (int)PlayerUnit.PlayerSkill[i].APCost)
            {
                if (PlayerUnit.PlayerSkill[i].SkillName == BtnName)
                {
                    Execute = true;
                    SkillNameUsed = PlayerUnit.PlayerSkill[i];
                    CritHit = StatusCheck(i);
                }
                
            }
            else
            {
                InfoHUD.InfoText.text = "Insuficient AP Choose another skill!";
                yield return new WaitForSeconds(1f);
            }
        }
        if (!Execute)
        {
            StartCoroutine(PlayerTurn());
        }
        else
        {
            bool EnemyIsDead;
            if (BtnName == "X")
            {
                Debug.Log("Player Deals : 10");
                EnemyIsDead = EnemyUnit.TakeDamage(10);
                PlayerHUD.SetUI(PlayerUnit, PlayerUnit.CurrentHP, PlayerUnit.AP);
                EnemyHUD.SetUI(EnemyUnit, EnemyUnit.CurrentHP);
                InfoHUD.SetInfoText(PlayerUnit.UnitName + " uses : normal attack!");
                yield return new WaitForSeconds(2f);
            }
            else
            {
                PlayerUnit.AP -= (int)SkillNameUsed.APCost;
                Debug.Log("Player Deals : " + SkillNameUsed.Damage * CritHit);
                EnemyIsDead = EnemyUnit.TakeDamage((int)(SkillNameUsed.Damage * CritHit));
                PlayerHUD.SetUI(PlayerUnit, PlayerUnit.CurrentHP, PlayerUnit.AP);
                EnemyHUD.SetUI(EnemyUnit, EnemyUnit.CurrentHP);
                InfoHUD.SetInfoText(PlayerUnit.UnitName + " uses : " + SkillNameUsed.SkillName + "!");
                yield return new WaitForSeconds(2f);
            }            

            if (EnemyIsDead)
            {
                state = BattleState.Won;
                StartCoroutine(EndBattle());
            }
            else
            {
                if (state == BattleState.Stun)
                {
                    InfoHUD.SetInfoText(EnemyUnit.UnitName + " is stunned");
                    yield return new WaitForSeconds(2f);
                    state = BattleState.PlayerTurn;
                    StartCoroutine(PlayerTurn());
                }
                else if (state == BattleState.Poison)
                {
                    InfoHUD.SetInfoText(EnemyUnit.UnitName + " is Poisoned Takes" + SkillNameUsed.PoisonDamage + "Damage");
                    EnemyIsDead = EnemyUnit.TakeDamage((int)SkillNameUsed.PoisonDamage);
                    yield return new WaitForSeconds(2f);
                    if (EnemyIsDead)
                    {
                        state = BattleState.Won;
                        StartCoroutine(EndBattle());
                    }
                    else
                    {
                        state = BattleState.EnemyTurn;
                        StartCoroutine(EnemyTurn());
                    }
                }
                else
                {
                    state = BattleState.EnemyTurn;
                    StartCoroutine(EnemyTurn());
                }
            }
        }        
    }    

    private IEnumerator EnemyTurn()
    {
        InfoHUD.SetInfoText(EnemyUnit.UnitName + " attacks!");
        yield return new WaitForSeconds(1f);
        bool PlayerIsDead = PlayerUnit.TakeDamage(Random.Range(10, 50));
        PlayerHUD.SetUI(PlayerUnit, PlayerUnit.CurrentHP, PlayerUnit.AP);
        if (PlayerIsDead)
        {
            state = BattleState.Lost;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.PlayerTurn;
            StartCoroutine(PlayerTurn());
        }
    }

    private IEnumerator EndBattle()
    {
        if (state == BattleState.Won)
        {
            InfoHUD.SetInfoText("Victory! Returning to main menu..");
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (state == BattleState.Lost)
        {
            Debug.Log("Lost");
            InfoHUD.SetInfoText("You lost! The end is nigh.. Returning to main menu..");
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void SkillNameAssign()
    {
        for (int i = 0; i < PlayerUnit.PlayerSkill.Count; i++)
        {
            if (PlayerUnit.PlayerSkill[i].SkillName != null)
            {
                ListSkill[i].text = PlayerUnit.PlayerSkill[i].SkillName;
                APCostText[i].text = ((int)PlayerUnit.PlayerSkill[i].APCost).ToString();
                DamageText[i].text = ((int)PlayerUnit.PlayerSkill[i].Damage).ToString();
            }
        }
    }
    private float StatusCheck(int i)
    {
        Debug.Log(PlayerUnit.PlayerSkill[i].StunProc);
        Debug.Log(PlayerUnit.PlayerSkill[i].PoisonProc);
        Debug.Log(PlayerUnit.PlayerSkill[i].CritProc);
        float Multiplier = 100;
        float stun = PlayerUnit.PlayerSkill[i].StunProc * Multiplier;
        float poison = (PlayerUnit.PlayerSkill[i].PoisonProc * Multiplier);
        float crit = (PlayerUnit.PlayerSkill[i].CritProc * Multiplier);
        Debug.Log(stun);
        Debug.Log(poison);
        Debug.Log(crit);
        float rand = Random.Range(1, 100);
        Debug.Log("Random :" + rand);
        if (PlayerUnit.PlayerSkill[i].StunProc > 0)
        {
            if (rand < stun)
            {
                //Debug.Log("Stun proced");
                state = BattleState.Stun;
            }
        }
        if (PlayerUnit.PlayerSkill[i].PoisonProc > 0)
        {
            if (rand < poison)
            {
                //Debug.Log("Poison proced");
                state = BattleState.Poison;
            }
        }
        if (PlayerUnit.PlayerSkill[i].CritProc > 0)
        {
            if (rand < crit)
            {
                //Debug.Log("Crit proced");
                return PlayerUnit.PlayerSkill[i].CritMultiplier;
            }
        }
        return 1;
    }
}
