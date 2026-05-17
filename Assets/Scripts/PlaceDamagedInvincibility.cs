using UnityEngine;

public class PlaceDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDuration;
    private InvincibilityController invincibilityController;

    private void Awake()
    {
        invincibilityController = GetComponent<InvincibilityController>();
    }

    public void StartInvincibility()
    {
        invincibilityController.StartInvincibility(invincibilityDuration);
    }
}
