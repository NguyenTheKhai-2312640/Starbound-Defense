using System.Collections;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private Health healthController;
    private PlayerArmor takeDamageController;

    private void Awake()
    {
        takeDamageController = GetComponent<PlayerArmor>();
        healthController = GetComponent<Health>();
    }

    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        takeDamageController.IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        takeDamageController.IsInvincible = false;
    }
}
