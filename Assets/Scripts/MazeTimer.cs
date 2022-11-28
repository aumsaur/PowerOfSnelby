using UnityEngine;
using TMPro;

public class MazeTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerMinutes;
    [SerializeField] private TMP_Text timerSeconds;
    [SerializeField] private TMP_Text timerSeconds100;

    private float startTime;
    private float stopTime;
    private float timerTime;
    private bool isRunning = false;

    // Use this for initialization
    void Start()
    {
        TimerReset();
    }

    public void TimerStart()
    {
        if (!isRunning)
        {
            Debug.Log("START");
            isRunning = true;
            startTime = Time.time;
        }
    }

    public float TimerStop()
    {
        if (isRunning)
        {
            Debug.Log("STOP");
            isRunning = false;
            stopTime = timerTime;
        }
        return stopTime;
    }

    public void TimerReset()
    {
        Debug.Log("RESET");
        stopTime = 0;
        isRunning = false;
        timerMinutes.text = timerSeconds.text = timerSeconds100.text = "00";
    }

    // Update is called once per frame
    void Update()
    {
        timerTime = stopTime + (Time.time - startTime);
        int minutesInt = (int)timerTime / 60;
        int secondsInt = (int)timerTime % 60;
        int seconds100Int = (int)(Mathf.Floor((timerTime - (secondsInt + minutesInt * 60)) * 100));

        if (isRunning)
        {
            timerMinutes.text = (minutesInt < 10) ? "0" + minutesInt : minutesInt.ToString();
            timerSeconds.text = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
            timerSeconds100.text = (seconds100Int < 10) ? "0" + seconds100Int : seconds100Int.ToString();
        }
    }
}