using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerDuration = 3f * 60f; //Duration of the timer in seconds

    [SerializeField] private float flashDuration = 1f; //The full length of the flash

    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI separator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;

    private bool stopTimer;

    private float flashTimer;

    private float timer;

    private void Start()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        stopTimer = false;

        timer = timerDuration;

        SetTextDisplay(true); // trigger to display timer
    }

    void Update()
    {
        // time remain then keep update
        if (timer > 0 && !stopTimer)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        // timer out then flash
        else
        {
            stopTimer = true;
            FlashTimer();
        }
    }

    private void UpdateTimerDisplay(float time)
    {
        if (time < 0)
        {
            time = 0;
        }

        if (time > 3660)
        {
            Debug.LogError("Timer cannot display values above 3660 seconds");
            ErrorDisplay();
            return;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{01:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    private void ErrorDisplay()
    {
        firstMinute.text = "8";
        secondMinute.text = "8";
        firstSecond.text = "8";
        secondSecond.text = "8";
    }

    private void FlashTimer()
    {
        //if (countDown && timer != 0)
        //{
        //    timer = 0;
        //    UpdateTimerDisplay(timer);
        //}

        //if (!countDown && timer != timerDuration)
        //{
        //    timer = timerDuration;
        //    UpdateTimerDisplay(timer);
        //}

        timer = timer > 0 ? timer : 0;

        if (flashTimer <= 0)
        {
            flashTimer = flashDuration;
        }
        else if (flashTimer <= flashDuration / 2)
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
        else
        {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        }
    }

    private void SetTextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        separator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }

    public float StopTimer()
    {
        stopTimer = true;
        return timer;
    }
}