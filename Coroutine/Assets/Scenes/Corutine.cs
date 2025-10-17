using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corutine : MonoBehaviour
{
    [SerializeField] GameObject Button;
    public float timerDuration = 10f;
    public Image lineImage;
    private float currentTime;

    void Start()
    {
        currentTime = timerDuration;
    }

    IEnumerator Perk1()
    {
        Button.SetActive(false);
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime; 
            float lineFillAmount = currentTime / timerDuration;
            lineImage.fillAmount = lineFillAmount; 
            yield return null; 
        }
        currentTime = 10;
        float fillAmount = currentTime / timerDuration; 
        lineImage.fillAmount = fillAmount;
        Button.SetActive(true);
    }

    public void Perk()
    {
        currentTime = timerDuration;
        StartCoroutine(Perk1());
    }
}
