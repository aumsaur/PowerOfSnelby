using System.Collections;
using UnityEngine;

public enum BattleState { START , GENERATE, WAITFORPLAYER, RIGHT, WRONG, WON, LOST}

// START -> GENERATE -> WAITFORPLAYER -> VALIDATE -> TIMEREMAIN -> GENERATE -> ... -> VALIDATE -> TIMEUP -> END -> CONCLUDE

public class BattleHandler : MonoBehaviour
{
    public static BattleState state;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform enemyStation;

    [SerializeField] private Vector2 input;

    [Tooltip("x: On Correct\ny: On Incorrect"), SerializeField] private Vector2 flatScore = new Vector2(50,30);

    [SerializeField] private int attempts;

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
        input = CharacterHUD.currentInstance.currentInputEquation;

        yield return new WaitForSeconds(3);

        Timer.currentInstance.ResetTimer();

        UpdateProblem();
    }

    private void EndBattle()
    {
        //dialogueText.text = state == BattleState.WON ? "Win" : state == BattleState.LOST ? "Defeat" : dialogueText.text;
    }

    private IEnumerator UpdateProblem()
    {
        state = BattleState.GENERATE;

        solveEq = ProblemGenerator.GenerateEquation();

        Debug.Log(solveEq.problem + ": " + solveEq.answer);

        // Handle Problem UI

        CharacterHUD.currentInstance.UpdateEquation("...");

        yield return new WaitForSeconds(1);

        CharacterHUD.currentInstance.UpdateEquation(solveEq.problem);
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
            // Deduct Flatscore, Reset multiplier, Add attempt
            multiplier = 1;
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

        CharacterHUD.currentInstance.UpdateStreak(multiplier);

        // Continue or not?
        if (Timer.currentInstance.getTimeRemains > 0)
        {
            if (state == BattleState.WRONG)
            {
                ScoreHandler.currentInstance.AddScore(-(int)Mathf.Abs(flatScore.y));
                // message, user wrong
            }
            if (state == BattleState.RIGHT || attempts > 4)
            {
                ScoreHandler.currentInstance.AddScore((int)Mathf.Abs(attempts <= 4 ? flatScore.x - ((attempts - 1) * 10) : flatScore.x - 30) * 1 + multiplier/10);
                // message, user right
                UpdateProblem();
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
        
        CharacterHUD.currentInstance.UpdateInputEquation(input);
    }

    public void OnPowerButton(bool isRaise)
    {
        input.y += isRaise ? (input.y < 25 ? 1 : -24) : (input.y > 1 ? -1 : 24);
        
        CharacterHUD.currentInstance.UpdateInputEquation(input);
    }
}
