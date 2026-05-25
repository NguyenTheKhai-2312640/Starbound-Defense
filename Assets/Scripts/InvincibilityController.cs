using System.Collections;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private PlayerArmor takeDamageController;

    private void Awake()
    {
        takeDamageController = GetComponent<PlayerArmor>();
    }

    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        // Armor
        takeDamageController.IsInvincible = true;

        yield return new WaitForSeconds(invincibilityDuration);

        takeDamageController.IsInvincible = false;
    }
}
