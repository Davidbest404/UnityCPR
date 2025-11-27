using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadSphere : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private LayerMask _layerMask2;

    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMaskUtil.ContainsLayer(_layerMask, collision.gameObject.layer))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (LayerMaskUtil.ContainsLayer(_layerMask2, collision.gameObject.layer))
        {
            gameObject.SetActive(false);
        }
    }
}
