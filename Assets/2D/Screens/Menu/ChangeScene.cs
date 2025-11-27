using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string NextSceneName;

    public void Change()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
