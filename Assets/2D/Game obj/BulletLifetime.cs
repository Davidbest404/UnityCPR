using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
    public float lifetime = 3f; // Сколько времени пуля живет (секунды)

    void Start()
    {
        Destroy(gameObject, lifetime); // Удаляем объект через указанное время
    }
}