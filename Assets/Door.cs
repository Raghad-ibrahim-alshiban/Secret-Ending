using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public GameObject endPanel;
    public AudioSource winSound;

    bool near = false;
    PlayerKey player;
    public Timer timer;

    void Start()
    {
        endPanel.SetActive(false);
    }

    void Update()
    {
        if (near && Input.GetKeyDown(KeyCode.E))
        {
            if (player != null && player.hasKey)
            {
                StartCoroutine(Win()); // 🔥 هنا التعديل
            }
        }
    }

   IEnumerator Win()
{
    timer.StopTimer();
    Debug.Log("WIN 🎉");

    endPanel.SetActive(true);

    if (winSound != null)
    {
        winSound.Play();
        yield return new WaitForSeconds(winSound.clip.length);
    }

    // ⛔ وقف اللعبة بعد ما يخلص الصوت
    Time.timeScale = 0f;

    // ✨ خلي الماوس يشتغل
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
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