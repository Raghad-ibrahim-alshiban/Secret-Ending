using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    public GameObject winUI;

    void Start()
    {
        winUI.SetActive(false);
    }

    public void ShowWin()
    {
        winUI.SetActive(true);
    }
}