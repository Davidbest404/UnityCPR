using UnityEngine;
using UnityEngine.UI;

public class ObjectHealth : MonoBehaviour
{
    [SerializeField] public float currentHealth;
    [SerializeField] public float damage;
    [SerializeField] public Image healthImage;
    [SerializeField] public string tagName;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Death(); // Вызываем функцию смерти
        }
    }

    void UpdateHealthBar()
    {
        healthImage.fillAmount = currentHealth;
    }

    public void Death()
    {
        
    }
}