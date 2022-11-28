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

    [SerializeField] private TMP_Text basePlayerText;
    [SerializeField] private TMP_Text powerPlayerText;
    [SerializeField] private TMP_Text[] baseEnemyText;
    [SerializeField] private TMP_Text[] powerEnemyText;

    [SerializeField] private GameObject floatingTextPrefabs;
    private GameObject newFloatingText;

    [VectorLabels("Base Input", "Power Input"), SerializeField] private Vector2 input = new Vector2(1,1);

    [SerializeField] private float comboTime;

    [SerializeField] private Text dialogueText;

    private int multiplier = 1;
    [SerializeField] private TMP_Text multiplierText;

    private CharacterAttribute playerAttribute, enemyAttribute;

    private Solve solveEq;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        basePlayerText.text = input.x.ToString();
        powerPlayerText.text = input.y.ToString();

        StartCoroutine(SetupBattle());
    }

    private void Update()
    {
        
    }

    private IEnumerator SetupBattle()
    {
        GameObject player = Instantiate(playerPrefab, playerStation);
        playerAttribute = player.GetComponent<CharacterAttribute>();

        GameObject enemy = Instantiate(enemyPrefab, enemyStation);
        enemyAttribute = enemy.GetComponent<CharacterAttribute>();

        yield return new WaitForSeconds(1);

        state = BattleState.GENERATE;
        UpdateProblem();
    }

    private void EndBattle()
    {
        dialogueText.text = state == BattleState.WON ? "Win" : state == BattleState.LOST ? "Defeat" : dialogueText.text;
    }

    private void UpdateProblem()
    {
        solveEq = ProblemGenerator.GenerateEquation();

        Debug.Log(solveEq.problem + ": " + solveEq.answer);
    }

    private bool CheckAnswer(float input)
    {
        // in case of user correct or not
        return input == solveEq.answer;
    }

    public void OnSubmitButton()
    {
        // validation user input
        if (!CheckAnswer(Mathf.Pow(input.x, input.y)))
        {
            if (playerAttribute.healthValue > 0)
            {
                playerAttribute.DecreaseHealth(1);
            }
            multiplier = 1;
            state = BattleState.WRONG;
        }
        else
        {
            // if combo time frame dont run out ; ++multiplier
            if (enemyAttribute.healthValue > 0)
            {
                enemyAttribute.DecreaseHealth(multiplier);
            }
            multiplier += 1;

            state = BattleState.RIGHT;
        }

        // generate new problem
        UpdateProblem();
    }

    public void OnRaisePowerButton()
    {
        if (input.y < 24)
        {
            input.y += 1;
        }
        else
            input.y = 0;
    }

    public void OnRaiseBaseButton()
    {
        if (input.x < 24)
        {
            input.x += 1;
        }
        else
            input.x = 0;
    }

    public void OnReducePowerButton()
    {
        if (input.y < 1)
        {
            input.y = 25;
        }
        else
            input.y -= 1;
    }

    public void OnReduceBaseButton()
    {
        if (input.x < 1)
        {
            input.x = 25;
        }
        else
            input.x -= 1;
    }
}
