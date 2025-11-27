using UnityEngine;

public class Floating : MonoBehaviour
{
    // Настройки поведения в Инспекторе
    [SerializeField] private float rotationAngle = 10f;           // Максимальный угол наклона
    [SerializeField] private float positionAmplitudeX = 0.5f;     // Амплитуда колебаний по оси X
    [SerializeField] private float positionAmplitudeY = 0.5f;     // Амплитуда колебаний по оси Y
    [SerializeField] private float animationSpeed = 1f;           // Скорость анимации

    private Transform myTransform;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float timer = 0f;

    void Start()
    {
        myTransform = transform;
        initialPosition = myTransform.position;
        initialRotation = myTransform.rotation;
    }

    void Update()
    {
        timer += Time.deltaTime * animationSpeed;

        // Рассчитываем новую позицию и угол поворота
        float xOffset = Mathf.Sin(timer) * positionAmplitudeX;
        float yOffset = Mathf.Cos(timer) * positionAmplitudeY;
        float zRotation = Mathf.Sin(timer) * rotationAngle;

        // Устанавливаем новые координаты и угол поворота плавно
        myTransform.position = initialPosition + new Vector3(xOffset, yOffset, 0f);
        myTransform.rotation = Quaternion.Euler(0f, 0f, initialRotation.eulerAngles.z + zRotation);
    }
}