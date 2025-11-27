using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] public GameObject pauseScreen;

    [SerializeField] private bool isPaused = false;
    [SerializeField] private float timeScaleBeforePause = 1f;

    [SerializeField] public InputActionAsset inputActions;
    private InputAction escapeAction;

    void Awake()
    {
        escapeAction = inputActions.FindActionMap("Player").FindAction("ESC");
    }

    void OnEnable()
    {
        // подписываемся на событие "выполнено"
        escapeAction.Enable();
        escapeAction.performed += EscapeAction_performed;
    }

    void OnDisable()
    {
        // отключаемся от события при деактивации компонента
        escapeAction.Disable();
        escapeAction.performed -= EscapeAction_performed;
    }

    private void EscapeAction_performed(InputAction.CallbackContext obj)
    {
        TogglePause();
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }

        isPaused = !isPaused;
    }

    private void Pause()
    {
        pauseScreen.SetActive(true);

        timeScaleBeforePause = Time.timeScale;
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        pauseScreen.SetActive(false);

        Time.timeScale = timeScaleBeforePause;
    }
}