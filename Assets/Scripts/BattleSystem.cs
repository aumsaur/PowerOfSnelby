using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private int solvedAnswer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateProblem()
    {

    }

    public void UpdateAnswer()
    {

    }

    public bool CheckAnswer(int input)
    {
        // in case of user correct or not

        if (input == solvedAnswer)
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
}
