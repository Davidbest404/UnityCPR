using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.05f; // Скорость движения
    private bool movingRight = true; // Направление движения
    private List<GameObject> enemyList = new List<GameObject>();
    private float screenWidth;
    private float enemyWidth;

    void Start()
    {
        // Получаем размеры экрана и ширину врага
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x * 2;
        enemyWidth = GetComponent<BoxCollider>().size.x;

        // Заполняем список всеми врагами
        foreach (Transform child in transform)
        {
            enemyList.Add(child.gameObject);
        }
    }

    void Update()
    {
        MoveEnemies();
    }

    void MoveEnemies()
    {
        // Вычисляем смещение
        float deltaX = speed * Time.deltaTime * (movingRight ? 1 : -1);

        // Поворачиваемся обратно, если достигли границы
        var furthestEnemyPosition = FindFurthestEnemyPosition();
        if ((furthestEnemyPosition.x + enemyWidth / 2 >= screenWidth && movingRight) ||
           (furthestEnemyPosition.x - enemyWidth / 2 <= -screenWidth && !movingRight))
        {
            DropDown();
            movingRight = !movingRight;
        }

        // Передвигаемся
        foreach (var enemy in enemyList)
        {
            enemy.transform.position += new Vector3(deltaX, 0, 0);
        }
    }

    void DropDown()
    {
        foreach (var enemy in enemyList)
        {
            enemy.transform.position -= new Vector3(0, enemyWidth, 0); // Спускаемся вниз
        }
    }

    Vector3 FindFurthestEnemyPosition()
    {
        Vector3 position = Vector3.zero;
        foreach (var enemy in enemyList)
        {
            if (!enemy.activeInHierarchy || enemy.GetComponent<Renderer>() == null) continue;
            position = enemy.transform.position;
        }
        return position;
    }
}