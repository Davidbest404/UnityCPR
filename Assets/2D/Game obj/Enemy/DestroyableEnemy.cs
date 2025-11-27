using UnityEngine;

public class DestroyableEnemy : MonoBehaviour
{
    public GameObject explosionPrefab; // Вспышка взрыва
    private EnemyController controller;

    void Start()
    {
        controller = GameObject.Find("EnemyGroup").GetComponent<EnemyController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_Bullet"))
        { // Предположим, что игрок стреляет снарядами с тегом Bullet
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false); // Или уничтожайте объект
            CheckEdge();
        }
    }

    void CheckEdge()
    {
        // Определение самого левого и правого врага
        Transform[] children = transform.parent.GetComponentsInChildren<Transform>();
        float minX = Mathf.Infinity;
        float maxX = -Mathf.Infinity;

        foreach (Transform t in children)
        {
            if (t != transform.parent)
            {
                float posX = t.position.x;
                if (posX < minX) minX = posX;
                if (posX > maxX) maxX = posX;
            }
        }

        // Сдвиг группы относительно нового края
        float offset = transform.position.x - minX;
        foreach (Transform t in children)
        {
            if (t != transform.parent)
            {
                t.position += new Vector3(offset, 0, 0);
            }
        }
    }
}