using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float time = 20f;
    bool hasKey = false;

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            // إذا خلص الوقت، تبغينه يعيد اللعبة ولا يروح للمنيو؟ 
            // حالياً خليته يعيد اللعبة، وإذا تبغينه يروح للمنيو غيريها لـ GoToMenu();
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

    // هذه الدالة للزر عشان يرجع للمنيو
    public void GoToMenu()
    {
        Time.timeScale = 1f; 
        // استبدلي كلمة "Start" باسم مشهد البداية عندك بالضبط بين القوسين
        SceneManager.LoadScene("Start"); 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}