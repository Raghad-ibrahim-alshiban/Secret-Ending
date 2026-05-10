using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    // 🔑 هل اللاعب أخذ المفتاح؟
    public bool hasKey = false;

    // (اختياري) عشان نشوف في الـ Console
    public void GiveKey()
    {
        hasKey = true;
    }
}