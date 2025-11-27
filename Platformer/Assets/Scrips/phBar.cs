using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phBar : MonoBehaviour
{
    Image playerHealthBar;
    private MyHP myHealth;
    public float HP;
    public Transform player;
    private Vector3 smoothPosition;

    private void Start()
    {
        myHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<MyHP>();
        playerHealthBar = GetComponent<Image>();
        HP = myHealth.myHealth;
    }

    void Update()
    {
        playerHealthBar.fillAmount = myHealth.myHealth / HP;
        smoothPosition = Vector3.Lerp(transform.position, player.position + new Vector3(0, 1.5f, 0), 0.1f);
        transform.position = smoothPosition;
    }
}

