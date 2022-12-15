using System.Collections;
using UnityEngine;

public enum BattleState { START , GENERATE, WAITFORPLAYER, RIGHT, WRONG, CONCLUDE,WON, LOST}

// START -> GENERATE -> WAITFORPLAYER -> VALIDATE -> TIMEREMAIN -> GENERATE -> ... -> VALIDATE -> TIMEUP -> END -> CONCLUDE

public class BattleHandler : MonoBehaviour
{
    public static BattleState state;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform enemyStation;

    [SerializeField] private Vector2 input;
    [SerializeField] private bool sign = true;

    [SerializeField] private int progressRequire = 10;
    [Tooltip("x: On Correct\ny: On Incorrect\n z: On Over"), SerializeField] private Vector3 flatScore = new Vector3(50, 10, 40);

    [SerializeField] private int attempts;

    [SerializeField] private float timerDuration = 3f * 60f; //Duration of the timer in seconds

    //[SerializeField] private Text dialogueText;

    private int multiplier = 1;

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
        input = HUDHandler.currentInstance.currentInputEquation;
        Timer.currentInstance.timerDuration = timerDuration;
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
        //return sign ? Mathf.Pow(input.x, input.y) == solveEq.answer : Mathf.Pow(input.x, input.y * -1) == solveEq.answer;
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
