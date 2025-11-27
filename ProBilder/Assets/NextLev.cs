using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLev : MonoBehaviour
{
    [SerializeField] public string nextSceneName = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок коснулся зоны перехода");

            // Переход на заданную сцену
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
