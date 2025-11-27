using UnityEngine;
using UnityEngine.InputSystem;

public class ShootBullet : MonoBehaviour
{
    // Компоненты и настройки
    [SerializeField] public GameObject bulletPrefab;    // Префаб пули
    [SerializeField] public GameObject parentGameZone;  // Общий родитель (GameZone)
    [SerializeField] public float shootForce = 8f;      // Сила выстрела (скорость пули)
    [SerializeField] public float fireRate = 0.5f;      // Интервал между выстрелами (в секундах)
    [SerializeField] public AudioSource audioSource;    // Аудио-компонент для воспроизведения звука
    [SerializeField] public AudioClip shootSoundClip;   // Звук выстрела
    [SerializeField] public Vector3 Scale;   // Звук выстрела

    [SerializeField] private float nextFireTime = 0f;  // Таймер следующего возможного выстрела

    [SerializeField] public InputActionAsset inputActions;
    private InputAction fireAction;

    void Awake()
    {
        fireAction = inputActions.FindActionMap("Player").FindAction("Attack");
    }

    void OnEnable()
    {
        // подписываемся на событие "выполнено"
        fireAction.Enable();
        fireAction.performed += FireAction_performed;
    }

    void OnDisable()
    {
        // отключаемся от события при деактивации компонента
        fireAction.Disable();
        fireAction.performed -= FireAction_performed;
    }

    private void FireAction_performed(InputAction.CallbackContext obj)
    {
        if (Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireBullet()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletInstance.transform.SetParent(parentGameZone.transform, true);
        bulletInstance.transform.localScale = Scale;
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(0, shootForce), ForceMode2D.Impulse);
        audioSource.PlayOneShot(shootSoundClip);
    }
}