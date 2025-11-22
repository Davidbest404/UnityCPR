using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject winGameScreen;
    [SerializeField] private LayerMask _layerMask;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask, collision.gameObject.layer))
        {
            winGameScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
