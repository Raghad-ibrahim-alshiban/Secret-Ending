using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PlayerKey pk = other.GetComponent<PlayerKey>();

            if (pk != null)
            {
                pk.hasKey = true;
                Debug.Log("🔑 KEY TAKEN");
                gameObject.SetActive(false);
            }
        }
    }
}