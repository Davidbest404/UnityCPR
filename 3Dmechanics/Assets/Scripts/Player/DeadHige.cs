using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadHige : MonoBehaviour
{
    [SerializeField] private int _hight;

    void Update()
    {
        if (transform.position.y <= _hight)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
