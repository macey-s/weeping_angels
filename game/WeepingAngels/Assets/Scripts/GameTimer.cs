using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TextMeshProUGUI timerText;
    private bool timerRunning = false;

    void Update()
    {
        if (!timerRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            timerRunning = false;

            // win
        }

        timerText.text = Mathf.Ceil(timeRemaining).ToString();
    }

    public void StartTimer()
    {
        timerRunning = true;
    }
}
