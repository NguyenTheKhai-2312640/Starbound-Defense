using UnityEngine;
using UnityEngine.Events;

public class PlayerArmor : MonoBehaviour
{
    [Header("Armor")]
    [SerializeField]
    public float maxArmor;
    [SerializeField]
    public float currentArmor;

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;

    public float RemainingHealthPercentage
    {
        get
        {
            return currentArmor / maxArmor;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (currentArmor == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        currentArmor -= damageAmount;
        OnHealthChanged.Invoke();

        if (currentArmor < 0)
        {
            currentArmor = 0;
        }
        
        if (currentArmor == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }

    }

    public void AddHealth(float amountToAdd)
    {
        if (currentArmor == maxArmor)
        {
            return;
        }
        currentArmor += amountToAdd;
        OnHealthChanged.Invoke();
        if
        (currentArmor > maxArmor)
            currentArmor = maxArmor;
    }
}
