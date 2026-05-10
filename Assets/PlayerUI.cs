using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject pressEUI;

    void Start()
    {
        Debug.Log("PlayerUI Running");

        if (pressEUI != null)
            pressEUI.SetActive(false);
    }

    public void Show()
    {
        Debug.Log("Show UI");
        if (pressEUI != null)
            pressEUI.SetActive(true);
    }

    public void Hide()
    {
        Debug.Log("Hide UI");
        if (pressEUI != null)
            pressEUI.SetActive(false);
    }
}