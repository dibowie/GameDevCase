using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Image healbarSprite;
    
    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        float fillAmount = currentHealth / maxHealth;
        healbarSprite.DOFillAmount(fillAmount, 0.5f);
    }
}
