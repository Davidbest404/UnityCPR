using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyHP : MonoBehaviour
{
    public int myHealth = 10;
    Transform playerPos;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (myHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("GameOver");
        }
    }

    public void TakeMyDamage(int myDamage)
    {
        myHealth -= myDamage;

        anim.SetTrigger("playerDamage");

        playerPos = GetComponent<Transform>();
        playerPos.position = new Vector3(playerPos.position.x - 0.5f - 0.5f - 0.5f, playerPos.position.y + 0.7f, playerPos.position.z);

    }
    



}
