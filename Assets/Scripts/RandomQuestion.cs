using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomQuestion : MonoBehaviour
{
    public int randomPattern = 1;
    private int minPatternRange = 1;
    private int maxPatternRange = 18;
    public float baseNumber1 = 1;
    public float powerNumber1 = 1;
    public float baseNumber2 = 1;
    public float powerNumber2 = 1;
    public float baseNumber3 = 1;
    public float powerNumber3 = 1;
    public float powerNumber4 = 1;

    public float answer;

    public string questionRan;

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomNext()
    {
        randomPattern = Random.Range(minPatternRange, maxPatternRange);
        //check = false;

        if (randomPattern == 1) //num*num*num
        {
            baseNumber1 = Mathf.Round(Random.Range(2, 21));
            powerNumber1 = Mathf.Round(Random.Range(1, 8));

            string str = baseNumber1.ToString();
            for (int i = 1; i < powerNumber1; i++)
            {
                str += "*" + baseNumber1.ToString();
            }

            questionRan = str;
            answer = Mathf.Pow(baseNumber1, powerNumber1);
            //answerRan = "Answer = " + baseNumber1.ToString() + " ^ " + powerNumber1.ToString();
            //Debug.Log("Answer = " + answer.ToString());
            //"Answer = " + baseNumber1.ToString() + " ^ " + powerNumber1.ToString();
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 2) //a
        {
            baseNumber1 = Mathf.Round(Random.Range(2, 8));
            if (baseNumber1 > 5)
            {
                powerNumber1 = Mathf.Round(Random.Range(1, 3));
            }
            else if (baseNumber1 > 3)
            {
                powerNumber1 = Mathf.Round(Random.Range(1, 4));
            }
            else
            {
                powerNumber1 = Mathf.Round(Random.Range(1, 5));
            }

            answer = Mathf.Pow(baseNumber1, (powerNumber1));
            questionRan = answer.ToString();

            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 3) //(n ^ a) * (n ^ b)
        {
            baseNumber1 = Mathf.Round(Random.Range(2, 21));
            powerNumber1 = Mathf.Round(Random.Range(1, 15));
            powerNumber2 = Mathf.Round(Random.Range(1, 15));

            questionRan = "(" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") * (" +
                                baseNumber1.ToString() + " ^ " + powerNumber2.ToString() + ")";

            answer = Mathf.Pow(baseNumber1, (powerNumber1 + powerNumber2));
            //Debug.Log("(" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") * (" + 
            //                baseNumber1.ToString() + " ^ " + powerNumber2.ToString() + ")");

            //Debug.Log("Answer = " + answer.ToString());
            //Debug.Log("Answer = " + baseNumber1.ToString() + " ^ " + (powerNumber1 + powerNumber2).ToString());
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 4) // (n ^ a) * (n ^ b) * (n ^ c)
        {
            baseNumber1 = Mathf.Round(Random.Range(2, 21));
            powerNumber1 = Mathf.Round(Random.Range(1, 10));
            powerNumber2 = Mathf.Round(Random.Range(1, 10));
            powerNumber3 = Mathf.Round(Random.Range(1, 10));

            questionRan = "(" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") * (" +
                                baseNumber1.ToString() + " ^ " + powerNumber2.ToString() + ") * (" +
                                baseNumber1.ToString() + " ^ " + powerNumber3.ToString() + ")";

            answer = Mathf.Pow(baseNumber1, (powerNumber1 + powerNumber2 + powerNumber3));
            //Debug.Log("Answer = " + answer.ToString());
            //Debug.Log("Answer = " + baseNumber1.ToString() + " ^ " + (powerNumber1 + powerNumber2 + powerNumber3).ToString());
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 5) // (n ^ a) * (n ^ b) * (n ^ c) * (n ^ d)
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 21));
            powerNumber1 = Mathf.Round(Random.Range(1, 6));
            powerNumber2 = Mathf.Round(Random.Range(1, 6));
            powerNumber3 = Mathf.Round(Random.Range(1, 6));
            powerNumber4 = Mathf.Round(Random.Range(1, 6));

            questionRan = "(" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") * (" +
                            baseNumber1.ToString() + " ^ " + powerNumber2.ToString() + ") * (" +
                            baseNumber1.ToString() + " ^ " + powerNumber3.ToString() + ") * (" +
                            baseNumber1.ToString() + " ^ " + powerNumber4.ToString() + ")";

            answer = Mathf.Pow(baseNumber1, (powerNumber1 + powerNumber2 + powerNumber3 + powerNumber4));
            //Debug.Log("Answer = " + answer.ToString());
            //Debug.Log("Answer = " + baseNumber1.ToString() + " ^ " + (powerNumber1 + powerNumber2 + powerNumber3 + powerNumber4).ToString());
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 6) //(n ^ a) / (n ^ b)
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 21));
            powerNumber1 = Mathf.Round(Random.Range(2, 15));
            powerNumber2 = Mathf.Round(Random.Range(1, powerNumber1));

            questionRan = "(" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") / (" +
                            baseNumber1.ToString() + " ^ " + powerNumber2.ToString() + ")";
            answer = Mathf.Pow(baseNumber1, (powerNumber1 - powerNumber2));
            //Debug.Log("Answer = " + answer.ToString());
            //Debug.Log("Answer = " + baseNumber1.ToString() + " ^ " + (powerNumber1 - powerNumber2).ToString());
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 7) //(n ^ a) ^ b
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 21));
            powerNumber1 = Mathf.Round(Random.Range(1, 10));
            powerNumber2 = Mathf.Round(Random.Range(1, 10));

            questionRan = "(" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") ^ " + powerNumber2.ToString();
            answer = Mathf.Pow(baseNumber1, (powerNumber1 * powerNumber2));
            //Debug.Log("Answer = " + answer.ToString());
            //Debug.Log("Answer = " + baseNumber1.ToString() + " ^ " + (powerNumber1 * powerNumber2).ToString());
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 8) //n1^a * n2^a
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 6));
            baseNumber2 = Mathf.Round(Random.Range(1, 5));
            powerNumber1 = Mathf.Round(Random.Range(1, 16));

            questionRan = "(" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") * (" +
                                baseNumber2.ToString() + " ^ " + powerNumber1.ToString() + ")";

            answer = Mathf.Pow((baseNumber1 * baseNumber2), powerNumber1);
            //Debug.Log("Answer = " + answer.ToString());
            //Debug.Log("Answer = " + (baseNumber1 * baseNumber2).ToString() + " ^ " + powerNumber1.ToString());
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 9) //(n1^a * n2^a)^b
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 6));
            baseNumber2 = Mathf.Round(Random.Range(1, 6));
            powerNumber1 = Mathf.Round(Random.Range(1, 6));
            powerNumber2 = Mathf.Round(Random.Range(1, 6));

            questionRan = "( (" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") * (" +
                                  baseNumber2.ToString() + " ^ " + powerNumber1.ToString() + ") ) ^ " + powerNumber2.ToString();
            answer = Mathf.Pow((baseNumber1 * baseNumber2), (powerNumber1 * powerNumber2));
            //Debug.Log("Answer = " + (baseNumber1 * baseNumber2).ToString() + " ^ " + (powerNumber1 * powerNumber2).ToString());
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 10) //n1^a * n2^a * n3^a
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 4));
            baseNumber2 = Mathf.Round(Random.Range(1, 4));
            baseNumber3 = Mathf.Round(Random.Range(1, 4));
            powerNumber1 = Mathf.Round(Random.Range(1, 16));

            questionRan = "(" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") * (" +
                                baseNumber2.ToString() + " ^ " + powerNumber1.ToString() + ") * (" +
                                baseNumber3.ToString() + " ^ " + powerNumber1.ToString() + ")";

            answer = Mathf.Pow((baseNumber1 * baseNumber2 * baseNumber3), powerNumber1);
            //Debug.Log("Answer = " + answer.ToString());
            //Debug.Log("Answer = " + (baseNumber1 * baseNumber2 * baseNumber3).ToString() + " ^ " + powerNumber1.ToString());
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 11) // (n^a * n^b) / n^c
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 16));
            powerNumber1 = Mathf.Round(Random.Range(1, 15));
            powerNumber2 = Mathf.Round(Random.Range(1, 15));
            powerNumber3 = Mathf.Round(Random.Range(1, powerNumber1 + powerNumber2));

            questionRan = "(" + baseNumber1.ToString() + "^" + powerNumber1.ToString() + " * " +
                                baseNumber1.ToString() + "^" + powerNumber2.ToString() + ") / " +
                                baseNumber1.ToString() + "^" + powerNumber3.ToString();
            answer = Mathf.Pow(baseNumber1, (powerNumber1 + powerNumber2 - powerNumber3));
            //Debug.Log("Answer = " + baseNumber1.ToString() + " ^ " + (powerNumber1 + powerNumber2- powerNumber3).ToString());
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 12) // (n1 ^ a) / (n2 ^ a)
        {
            baseNumber2 = Mathf.Round(Random.Range(1, 7));
            powerNumber1 = Mathf.Round(Random.Range(1, 15));
            baseNumber1 = baseNumber2 * Mathf.Round(Random.Range(2, 5));

            questionRan = "(" + baseNumber1.ToString() + "^" + powerNumber1.ToString() + ") / (" +
                                baseNumber2.ToString() + "^" + powerNumber1.ToString() + ")";
            answer = Mathf.Pow((baseNumber1 / baseNumber2), powerNumber1);

            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 13) // 1 / (n ^ a)
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 16));
            powerNumber1 = Mathf.Round(Random.Range(1, 15));

            questionRan = "1 / (" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ")";
            answer = Mathf.Pow(baseNumber1, -powerNumber1);

            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 14) // n ^ 0
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 21));
            powerNumber1 = 0;

            questionRan = baseNumber1.ToString() + " ^ 0";
            answer = Mathf.Pow(baseNumber1, 0);

            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 15) // (1 / (n ^ a)) ^ b
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 16));
            powerNumber1 = Mathf.Round(Random.Range(1, 6));
            powerNumber2 = Mathf.Round(Random.Range(1, 6));

            questionRan = "(1 / (" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ")) ^ " + powerNumber2.ToString();
            answer = Mathf.Pow(baseNumber1, (-powerNumber1 * powerNumber2));

            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 16) // ((n1 ^ a) * (n2 ^ a)) / (n3 ^ a)
        {
            baseNumber2 = Mathf.Round(Random.Range(1, 4));
            baseNumber3 = Mathf.Round(Random.Range(1, 7));
            powerNumber1 = Mathf.Round(Random.Range(1, 15));
            baseNumber1 = baseNumber3 * Mathf.Round(Random.Range(2, 5));

            questionRan = "((" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") * (" +
                                 baseNumber2.ToString() + " ^ " + powerNumber1.ToString() + ")) / (" +
                                 baseNumber3.ToString() + " ^ " + powerNumber1.ToString() + ")";
            answer = Mathf.Pow(((baseNumber1 * baseNumber2) / baseNumber3), powerNumber1);

            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
        else if (randomPattern == 17) // ((n ^ a) / (n ^ b)) ^ c
        {
            baseNumber1 = Mathf.Round(Random.Range(1, 16));
            powerNumber1 = Mathf.Round(Random.Range(2, 10));
            powerNumber2 = Mathf.Round(Random.Range(1, powerNumber1));
            powerNumber3 = Mathf.Round(Random.Range(1, 6));

            questionRan = "((" + baseNumber1.ToString() + " ^ " + powerNumber1.ToString() + ") / (" +
                                 baseNumber1.ToString() + " ^ " + powerNumber2.ToString() + ")) ^ " +
                                 powerNumber3.ToString();
            answer = Mathf.Pow(baseNumber1, ((powerNumber1-powerNumber2)*powerNumber3));
            Debug.Log(questionRan);
            Debug.Log(answer.ToString());
        }
    }

    public float GetAnswer() //get answer
    {
        return answer;
    }

    public string QuestionRan()  //get randomed question
    {
        return questionRan;
    }
}