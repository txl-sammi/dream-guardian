using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private Text healthText;
    [SerializeField] private string type;
    [SerializeField] private Image healthFillImage;
    [SerializeField] private Image healthFillImageRound;

    private void Start()
    {
        if (healthManager != null)
        {
            healthManager.onHealthChanged.AddListener(UpdateHealthUI);
        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthText != null && healthManager != null)
        {
            //healthText.text = type + ": " + healthManager.CurrentHealth.ToString("F");
            healthText.text = ((int)healthManager.CurrentHealth).ToString("0");
        }

        if (healthManager != null && healthManager.startingHealth != 0)
        {
            float fillAmount = (float)healthManager.CurrentHealth / healthManager.startingHealth;
            if (healthFillImage != null)
            {
                healthFillImage.fillAmount = fillAmount;
            }
            if (healthFillImageRound != null)
            {
                healthFillImageRound.fillAmount = fillAmount;
            }
        }
    }
}
