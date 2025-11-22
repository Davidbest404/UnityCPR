using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private Transform allEnemys;
    [SerializeField] private GameObject finishPortal;
    bool canFinishing = false;

    private void Update()
    {
        canFinishing = true;
        for (int i = 0; i < allEnemys.childCount; i++)
        {
            if (allEnemys.GetChild(i).gameObject.activeInHierarchy)
            {
                canFinishing = false;
                break;
            }
        }
        finishPortal.SetActive(canFinishing);
    }
}
