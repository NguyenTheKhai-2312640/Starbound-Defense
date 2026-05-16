using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField]
    private Image currentHealthBarImage;
    [SerializeField]
    private Image currentArmorBarImage;

    public void UpdateHealthBar(Health health)
    {
        currentHealthBarImage.fillAmount = health.RemainingHealthPercentage;
    }

    public void UpdateArmorBar(PlayerArmor playerArmor)
    {
        currentArmorBarImage.fillAmount = playerArmor.RemainingHealthPercentage;
    }
}
