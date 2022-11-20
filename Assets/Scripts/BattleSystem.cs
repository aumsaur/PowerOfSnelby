using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START , GENERATE, WAITFORPLAYER, RIGHT, WRONG, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private BattleState state;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform enemyStation;

    [SerializeField] private Text dialogueText;

    [SerializeField] private TMP_Text baseInputText;
    [SerializeField] private TMP_Text powerInputText;

    [SerializeField] private float baseInput = 1;
    [SerializeField] private float powerInput = 1;

    private int solvedAnswer;
    
    private CharacterAttribute playerAttribute, enemyAttribute;

    private Solve solveEq;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
    }

    private IEnumerator SetupBattle()
    {
        GameObject player = Instantiate(playerPrefab, playerStation);
        playerAttribute = player.GetComponent<CharacterAttribute>();

        GameObject enemy = Instantiate(enemyPrefab, enemyStation);
        enemyAttribute = enemy.GetComponent<CharacterAttribute>();

        yield return new WaitForSeconds(1);

        state = BattleState.GENERATE;
    }

    private void EndBattle()
    {

    }

    private void UpdateProblem()
    {
        solveEq = ProblemGenerator.GenerateEquation();

        
    }

    private void UpdateAnswer()
    {

    }

    private bool CheckAnswer(int input)
    {
        // in case of user correct or not

        if (input == solveEq.answer)
        {
            // user correct then ...
            return true;
        }
        else
        {
            // user not correct then ...
            return false;
        }
    }

    public void OnSubmitButton()
    {
        // validation user input

        // monster turn

        // generate new problem
    }

    public void OnRaisePowerButton()
    {

    }

    public void OnRaiseBaseButton()
    {

    }

    public void OnRedycePowerButton()
    {

    }

    public void OnReduceBaseButton()
    {

    }
}
