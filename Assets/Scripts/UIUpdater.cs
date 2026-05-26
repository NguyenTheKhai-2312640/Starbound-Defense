using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    [SerializeField]
    private Image currentHealthBarImage;
    [SerializeField]
    private Image currentArmorBarImage;
    [SerializeField] 
    private TextMeshProUGUI coinText;

    public void UpdateHealthBar(Health health)
    {
        currentHealthBarImage.fillAmount = health.RemainingHealthPercentage;
    }

    public void UpdateArmorBar(PlayerArmor playerArmor)
    {
        currentArmorBarImage.fillAmount = playerArmor.RemainingArmorPercentage;
    }

    public void UpdateCoinUI(MoneyManager moneyManager)
    {
        coinText.text = moneyManager.RemainingCoinPercentage.ToString();
    }
}
