using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;              // ⏱️ مدة الوقت
    public TextMeshProUGUI timerText;         // 📺 عرض الوقت
    public AudioSource tickSound;             // 🔊 صوت كل ثانية

    bool isRunning = false;
    float lastSecond;

    void Start()
    {
        isRunning = true;
    }

    void Update()
    {
        if (!isRunning) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            isRunning = false;
            Debug.Log("⛔ Game Over");
        }

        // 📺 عرض الوقت
        timerText.text = Mathf.Ceil(timeLeft).ToString();

        // 🔊 صوت كل ثانية
        if (Mathf.Floor(timeLeft) != lastSecond)
        {
            lastSecond = Mathf.Floor(timeLeft);

            if (tickSound != null)
                tickSound.Play();
        }
    }

    // ⛔ إيقاف التايمر من الخارج
    public void StopTimer()
    {
        isRunning = false;

        if (tickSound != null)
            tickSound.Stop();
    }
}