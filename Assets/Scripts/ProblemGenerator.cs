using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering;

public struct Solve
{
    public string problem;
    public float answer;
}

public static class ProblemGenerator
{
    private static int m_minPattern = 1, m_maxPattern = 18;

    public static int minPattern { get { return m_minPattern; } set { m_minPattern = value; } }
    public static int maxPattern { get { return m_maxPattern; } set { m_minPattern = value; } }

    public static Solve GenerateEquation()
    {
        int patternSelected = Random.Range(m_minPattern, m_maxPattern);

        List<int> baseNumber = new List<int>();
        List<int> powNumber = new List<int>();

        int iteration;

        Solve m_Solve = new Solve();

        switch (patternSelected)
        {
            case 1: // n * n * n
            case 2: // n
                baseNumber.Add(Random.Range(2, 21));// base

                powNumber.Add(Random.Range(1, patternSelected == 1 ? 8 : baseNumber[0] < 5 ? 8 : baseNumber[0] < 10 ? 5 : 3));

                m_Solve.answer = Mathf.Pow(baseNumber[0], powNumber[0]);
                if (patternSelected == 1)
                {
                    for (int i = 0; i < powNumber[0]; i++)
                    {
                        m_Solve.problem = i == 0 ? baseNumber[0].ToString() : m_Solve.problem += "*" + baseNumber[0];
                    }
                }
                else
                {
                    m_Solve.problem = ((int)m_Solve.answer).ToString();
                }

                break;
            case 3: // 1 / (n ^ a)
                baseNumber.Add(Random.Range(1, 16));
                powNumber.Add(Random.Range(1, 16));

                m_Solve.answer = 1 / Mathf.Pow(baseNumber[0], powNumber[0]);
                m_Solve.problem = "1/(" + baseNumber[0] + "^" + powNumber[0] + ")";

                break;
            case 4: // n ^ 0
                baseNumber.Add(Random.Range(1, 21));

                m_Solve.answer = 1;
                m_Solve.problem = baseNumber[0] + "^0";

                break;
            case 5: // (n ^ a) * (n ^ b)
            case 6: // (n ^ a) * (n ^ b) * (n ^ c)
            case 7: // (n ^ a) * (n ^ b) * (n ^ c) * (n ^ d)
                baseNumber.Add(Random.Range(2, 15));

                iteration = patternSelected == 5 ? 2 : patternSelected == 6 ? 3 : 4;

                for (int i = 0; i < iteration; i++)
                {
                    powNumber.Add(Random.Range(1, 10));

                    m_Solve.problem = i == iteration - 1 ? baseNumber[0] + "^" + powNumber[i] :
                                                           baseNumber[0] + "^" + powNumber[i] + "*";

                    m_Solve.answer = i == 0 ? m_Solve.answer = Mathf.Pow(baseNumber[0], powNumber[i]) :
                                              m_Solve.answer *= Mathf.Pow(baseNumber[0], powNumber[i]);
                }

                break;
            case 8: // (n ^ a) / (n ^ b)
            case 9: // (n ^ a) ^ b
            case 10: // (1 / (n ^ a)) ^ b
                baseNumber.Add(Random.Range(1, 21));

                for (int i = 0; i < 2; i++)
                {
                    powNumber.Add(Random.Range(2, 15));
                }

                m_Solve.problem = patternSelected == 8 ? baseNumber[0] + "^" + powNumber[0] + "/" + baseNumber[0] + "^" + powNumber[1] :
                          patternSelected == 9 ? "(" + baseNumber[0] + "^" + powNumber[0] + ")" + powNumber[1] :
                                                 "1/" + "(" + baseNumber[0] + "^" + powNumber[0] + ")" + powNumber[1];

                m_Solve.answer = patternSelected == 8 ? Mathf.Pow(baseNumber[0], powNumber[0] - powNumber[1]) :
                         patternSelected == 9 ? Mathf.Pow(Mathf.Pow(baseNumber[0], powNumber[0]), powNumber[1]) :
                                                1 / Mathf.Pow(Mathf.Pow(baseNumber[0], powNumber[0]), powNumber[1]);

                break;
            case 11: // (n ^ a) * (n ^ b) / n ^ c
            case 12: // ((n ^ a) / (n ^ b)) ^ c
                baseNumber.Add(Random.Range(1, 21));

                for (int i = 0; i < 3; i++)
                {
                    powNumber.Add(Random.Range(2, i == 2 ? powNumber[0] + powNumber[1] : 15));
                }

                m_Solve.problem = patternSelected == 11 ? baseNumber[0] + "^" + powNumber[0] + "*" + baseNumber[0] + "^" + powNumber[1] + "/" + baseNumber[0] + "^" + powNumber[2] :
                                                 "(" + baseNumber[0] + "^" + powNumber[0] + ")/(" + baseNumber[0] + "^" + powNumber[1] + ")" + baseNumber[0] + "^" + powNumber[2];

                m_Solve.answer = patternSelected == 11 ? Mathf.Pow(baseNumber[0], powNumber[0] + powNumber[1] - powNumber[2]) :
                                                1 / Mathf.Pow(Mathf.Pow(baseNumber[0], powNumber[0] - powNumber[1]), powNumber[2]);

                break;
            case 13: // (n ^ a) * (n' ^ a)
            case 14: // (n ^ a) / (n' ^ a)
            case 15: // (n ^ a) * (n' ^ a) * (n'' ^ a)
            case 16: // ((n ^ a) * (n' ^ a)) / (n'' ^ a)
                powNumber.Add(Random.Range(1, 15));

                List<int> excludeList = new List<int>() { 13, 14 };

                iteration = excludeList.Contains(patternSelected) ? 2 : 3;

                for (int i = 0; i < iteration; i++)
                {
                    baseNumber.Add((patternSelected == 14 && i == 1) || (patternSelected == 16 && i == 2) ? 
                        baseNumber[i - 1] / Random.Range(1, 4) : 
                        Random.Range(1, 14));
                }

                m_Solve.answer = patternSelected == 14 ? Mathf.Pow(baseNumber[0], powNumber[0]) / Mathf.Pow(baseNumber[1], powNumber[0]) :
                                                 Mathf.Pow(baseNumber[0], powNumber[0]) * Mathf.Pow(baseNumber[1], powNumber[0]);

                m_Solve.answer = excludeList.Contains(patternSelected) ? m_Solve.answer : 
                                                                          patternSelected == 13 ? m_Solve.answer * Mathf.Pow(baseNumber[2], powNumber[0]) :
                                                                          m_Solve.answer / Mathf.Pow(baseNumber[2], powNumber[0]);

                m_Solve.problem = patternSelected == 14 ? "(" + baseNumber[0] + "^" + powNumber[0] + ")/(" + baseNumber[1] + "^" + powNumber[0] + ")" :
                                                  "(" + baseNumber[0] + "^" + powNumber[0] + ")*(" + baseNumber[1] + "^" + powNumber[0] + ")";

                m_Solve.problem = excludeList.Contains(patternSelected) ? m_Solve.problem :
                                                                           patternSelected == 13 ? m_Solve.problem + "*" + baseNumber[2] + "^" + powNumber[0] :
                                                                           m_Solve.problem + "/" + baseNumber[2] + "^" + powNumber[0];

                break;
            case 17: // ((n ^ a) * (n' ^ a))^b
                m_Solve.answer = 1;
                for (int i = 0; i < 2; i++)
                {
                    powNumber.Add(Random.Range(1, 6));
                    baseNumber.Add(Random.Range(1, 6));

                    m_Solve.answer *= Mathf.Pow(baseNumber[i], powNumber[0]);
                }

                m_Solve.answer = Mathf.Pow(m_Solve.answer, powNumber[1]);
                m_Solve.problem = "((" + baseNumber[0] + "^" + powNumber[0] + ") * (" + baseNumber[1] + "^" + powNumber[0] + "))^" + powNumber[1];

                break;
            default:
                break;
        }

        //foreach ()

        //m_Solve.answer = (int)Mathf.Pow(baseNumber[0], powNumber[0]);

        Debug.Log(m_Solve.problem);
        Debug.Log(m_Solve.answer);

        // * follow by number = this number is base, ^ follow by number = this number is pow
        return m_Solve;
    }
}