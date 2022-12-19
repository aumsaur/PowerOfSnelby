using System.Collections;
using UnityEngine;

public enum BattleState { START , GENERATE, WAITFORPLAYER, RIGHT, WRONG, CONCLUDE,WON, LOST}
public enum Difficulty { EASY, INTERMEDIATE, CHALLENGE }

// START -> GENERATE -> WAITFORPLAYER -> VALIDATE -> TIMEREMAIN -> GENERATE -> ... -> VALIDATE -> TIMEUP -> END -> CONCLUDE

public class BattleHandler : MonoBehaviour
{
    public static BattleState state;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private BattleUnit enemyBattleUnit;

    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform enemyStation;

    [SerializeField] private int attempts;
    [SerializeField] private bool debugMode;
    [SerializeField] private int debugTopic;

    private Vector2 input;
    private bool sign = true;

    private int progressRequire;
    private Vector3 flatScore;

    private Difficulty _difficulty;

    private int multiplier;

    private Solve solveEq;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    private IEnumerator SetupBattle()
    {
        GameObject player = Instantiate(playerPrefab, playerStation);

        GameObject enemy = Instantiate(enemyPrefab, enemyStation);

        yield return null;

        ProblemGenerator.patternPools = enemyBattleUnit.topics;
        
        input = HUDHandler.currentInstance.currentInputEquation;

        Timer.currentInstance.timerDuration = enemyBattleUnit.timeDuration[(int)_difficulty];
        flatScore = new Vector3(enemyBattleUnit.scorePositive[(int)_difficulty], enemyBattleUnit.scoreNegative[(int)_difficulty], 40);
        progressRequire = enemyBattleUnit.totalRequire[(int)_difficulty];

        StartCoroutine(HUDHandler.currentInstance.SetupHUD(sign, progressRequire));

        yield return new WaitForSeconds(3);

        Timer.currentInstance.ResetTimer();

        StartCoroutine(UpdateProblem());
    }

    private void EndBattle()
    {
        //dialogueText.text = state == BattleState.WON ? "Win" : state == BattleState.LOST ? "Defeat" : dialogueText.text;
        HUDHandler.currentInstance.ShowSummary((int)flatScore.z);
    }

    private IEnumerator UpdateProblem()
    {
        if (debugMode)
        {
            ProblemGenerator.debugMode = debugMode;
            ProblemGenerator.debugTopic = debugTopic;
        }

        state = BattleState.GENERATE;

        solveEq = ProblemGenerator.GenerateEquation();

        Debug.Log(solveEq.problem + ": " + solveEq.answer);

        // Handle Problem UI

        HUDHandler.currentInstance.UpdateEquation("...");

        yield return new WaitForSeconds(1);

        HUDHandler.currentInstance.UpdateEquation(solveEq.problem);
        state = BattleState.WAITFORPLAYER;
    }

    private bool CheckAnswer()
    {
        // in case of user correct or not
        if (sign)
        {
            return Mathf.Pow(input.x, input.y) == solveEq.answer;
        }
        else
        {
            return Mathf.Pow(input.x, input.y * -1) == solveEq.answer;
        }
    }

    public void OnSubmitButton()
    {
        if (state == BattleState.WAITFORPLAYER)
        {
            // validation user input
            if (!CheckAnswer())
            {
                // Deduct Flatscore, Reset multiplier, Add attempt
                multiplier = 0;
                attempts += 1;
                state = BattleState.WRONG;
            }
            else
            {
                // Add multiplier, score * multiplier, Reset attempt
                multiplier += 1;
                attempts = 0;
                state = BattleState.RIGHT;
            }
        }
        Debug.Log(Mathf.Pow(input.x, input.y) + ";" + solveEq.answer);
        HUDHandler.currentInstance.UpdateStreak(multiplier);

        // Continue or not?
        if (Timer.currentInstance.getTimeRemains > 0)
        {
            if (state == BattleState.WRONG)
            {
                ScoreHandler.currentInstance.AddScore(-(int)Mathf.Abs(flatScore.y));
                if (attempts < 5)
                {
                    state = BattleState.WAITFORPLAYER;
                }
                // message, user wrong
            }
            if (state == BattleState.RIGHT || attempts > 4)
            {
                ScoreHandler.currentInstance.AddScore((int)Mathf.Abs(flatScore.x * multiplier));
                // message, user right
                StartCoroutine(UpdateProblem());
            }            
        }
        else
        {
            EndBattle();
        }
    }

    public void OnBaseButton(bool isRaise)
    {
        input.x += isRaise ? (input.x < 25 ? 1 : -24) : (input.x > 1 ? -1 : 24);
        
        HUDHandler.currentInstance.UpdateInputEquation(input);
    }

    public void OnPowerButton(bool isRaise)
    {
        input.y += isRaise ? (input.y < 25 ? 1 : -24) : (input.y > 1 ? -1 : 24);
        
        HUDHandler.currentInstance.UpdateInputEquation(input);
    }

    public void OnPosNegButton()
    {
        sign = HUDHandler.currentInstance.UpdateSign();
    }
}
