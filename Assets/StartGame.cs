using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitButton()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }
}