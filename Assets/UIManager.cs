using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale in case it was changed
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor again
        Cursor.visible = false; // Hide the cursor again
        SceneManager.LoadScene("Start");
    }
}
