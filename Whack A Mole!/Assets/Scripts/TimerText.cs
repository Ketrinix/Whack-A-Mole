using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining;

    private bool timerEnded = false;

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;

            UpdateTimerText();
        }
        else
        {
            timeRemaining = 0f;
            timerEnded = true;
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = $"00:{Mathf.Ceil(timeRemaining):00}";
    }
}