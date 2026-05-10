using UnityEngine;

public class ChestInteract : MonoBehaviour
{
    public bool hasKey = false;
    public GameObject keyObject;
    public GameObject pressEUI;

    bool playerNear = false;

    void Start()
    {
        if (pressEUI != null)
            pressEUI.SetActive(false);

        if (keyObject != null)
            keyObject.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Chest Opened");
            OpenChest();
        }
    }
    void OpenChest()
    {
        if (keyObject != null){
              keyObject.SetActive(true);
        }

        gameObject.SetActive(false);
   }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (pressEUI != null)
                pressEUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            if (pressEUI != null)
                pressEUI.SetActive(false);
        }
    }
}