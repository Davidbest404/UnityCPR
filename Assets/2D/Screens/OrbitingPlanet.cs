using UnityEngine;

// Атрибуты используются для отображения полей в Инспекторе
[RequireComponent(typeof(Renderer))]
public class OrbitingPlanet : MonoBehaviour
{
    // Настройки орбиты
    public Transform centerObject;       // Солнце (центр вращения)
    public float orbitRadius = 10f;      // Радиус орбиты
    public float rotationSpeed = 1f;     // Скорость вращения по орбите
    public Vector3 orbitAngleOffset = new Vector3(0, 0, 0);   // Углы поворота орбитальной плоскости относительно центра
    
    // Камера
    public Camera mainCamera;            // Основная камера сцены
    public float sizeFactor = 10f;       // Коэффициент изменения размера планеты
    
    // Хранение начального масштаба планеты
    private Vector3 initialScale;
    
    void Start()
    {
        // Сохраняем исходный масштаб объекта
        initialScale = transform.localScale;
    }

    void LateUpdate()
    {
        // Определяем позицию планеты на орбите
        float angle = Time.timeSinceLevelLoad * rotationSpeed;
        float x = Mathf.Cos(angle) * orbitRadius;
        float y = Mathf.Sin(angle) * orbitRadius;
        
        // Преобразование координат в систему отсчета, наклоненную относительно центра
        Quaternion rotationQuaternion = Quaternion.Euler(orbitAngleOffset);
        Vector3 positionOnOrbit = rotationQuaternion * new Vector3(x, y, 0);
        
        // Вычисление конечной позиции планеты относительно центрального объекта
        transform.position = centerObject.position + positionOnOrbit;
        
        // Изменение размера планеты в зависимости от расстояния до камеры
        float distanceToCamera = Vector3.Distance(transform.position, mainCamera.transform.position);
        float scaleMultiplier = 1 / (distanceToCamera / sizeFactor);
        transform.localScale = initialScale * scaleMultiplier;
    }
}