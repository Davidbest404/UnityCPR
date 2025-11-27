using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnNewScene : MonoBehaviour
{
    public int levelToLoad;
    public Vector3 position;
    public VectorValue playerStorage;
    public GameObject playerHealthCanvas;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(levelToLoad);
        }
    }

}
