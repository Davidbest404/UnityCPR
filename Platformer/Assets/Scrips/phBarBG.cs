using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phBarBG : MonoBehaviour
{
    public Transform player;
    private Vector3 smoothPosition;

    void LateUpdate()
    {
        smoothPosition = Vector3.Lerp(transform.position, player.position + new Vector3(0, 1.5f, 0), 0.1f);
        transform.position = smoothPosition;
    }
}
