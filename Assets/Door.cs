using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    [Header("UI & Audio Settings")]
    public GameObject endPanel;
    public AudioSource winSound;      // صوت الزفة
    public AudioSource gameMusic;     // صوت اللعبة الأساسي
    public AudioSource timerSound;    // صوت التايمر

    [Header("References")]
    public Timer timer;
    bool near = false;
    PlayerKey player;

    void Start()
    {
        if (endPanel != null) endPanel.SetActive(false);
    }

    void Update()
    {
        if (near && Input.GetKeyDown(KeyCode.E))
        {
            if (player != null && player.hasKey)
            {
                Win(); 
            }
        }
    }

    void Win()
    {
        Debug.Log("WIN 🎉");

        // 1. وقف التايمر والأصوات المزعجة فوراً
        if (timer != null) timer.StopTimer();
        if (gameMusic != null) gameMusic.Stop();
        if (timerSound != null) timerSound.Stop();

        // 2. إظهار شاشة النهاية وتشغيل الزفة
        if (endPanel != null) endPanel.SetActive(true);
        if (winSound != null) winSound.Play();

        // 3. حل مشكلة الماوس (يرجعه طبيعي ويمسح أي صورة معلقة)
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // ملاحظة: إذا تبغين اللعبة توقف تماماً، شيلي علامتين السلاش عن السطر اللي تحت
        // Time.timeScale = 0f; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            near = true;
            player = other.GetComponent<PlayerKey>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            near = false;
        }
    }
}