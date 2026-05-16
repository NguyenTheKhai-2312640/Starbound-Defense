using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    public float maxHealth;
    [SerializeField]
    public float currentHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0)
        {
            return;
        }
        currentHealth -= damageAmount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (currentHealth == maxHealth)
        {
            return;
        }
        currentHealth += amountToAdd;
        if
        (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}
