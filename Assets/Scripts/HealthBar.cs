using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private Text healthText;
    [SerializeField] private string type;
    [SerializeField] private Image healthFillImage;
    [SerializeField] private Image healthFillImageRound;
    [SerializeField] private float restoreAmount;

    private void Start()
    {
        if (healthManager != null)
        {
            healthManager.onHealthChanged.AddListener(UpdateHealthUI);
        }

        UpdateHealthUI();
    }

    private void Update(){
        healthManager.Heal(restoreAmount*Time.deltaTime);
    }

    private void UpdateHealthUI()
    {

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
