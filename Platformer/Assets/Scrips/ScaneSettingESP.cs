using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScaneSettingESP : MonoBehaviour
{
    [SerializeField] public Button PauseButton;
    [SerializeField] public Button ContinueButton;
    [SerializeField] public Button RestartButton;
    [SerializeField] public Button BackInMenu;
    public int lvl;
    void Start()
    {   ContinueButton.gameObject.SetActive(false);
        PauseButton.onClick.AddListener(PauseButtonPressed);
        ContinueButton.onClick.AddListener(ContinueButtonPressed);
        RestartButton.onClick.AddListener(RestartButtonPressed);
        BackInMenu.onClick.AddListener(BackInMenuPressed);
        
    }
    public void PauseButtonPressed()
    {
        ContinueButton.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        BackInMenu.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ContinueButtonPressed()
    {
        ContinueButton.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        BackInMenu.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void BackInMenuPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

