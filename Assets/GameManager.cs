using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float time = 20f;
    bool hasKey = false;

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            RestartGame();
        }
    }

    public void GotKey()
    {
        hasKey = true;
        Debug.Log("روح للباب 🚪");
    }

    public bool HasKey()
    {
        return hasKey;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}