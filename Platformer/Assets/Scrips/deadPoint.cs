using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadPoint : MonoBehaviour
{

    public float hight = -25;

    void Update()
    {
        if (transform.position.y <= hight)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
