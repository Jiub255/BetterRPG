using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField] HealthSO playerHealthSO;
    [SerializeField] Image healthBarImage;
    [SerializeField] TextMeshProUGUI healthBarText;

    [SerializeField] HealthSO playerMagicSO;
    [SerializeField] Image magicBarImage;
    [SerializeField] TextMeshProUGUI magicBarText;

    private void Start()
    {
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        UpdateHealthBar();
        UpdateMagicBar();
    }

    void UpdateHealthBar()
    {
        healthBarImage.fillAmount = ((float)playerHealthSO.currentValue / playerHealthSO.maxValue);
        healthBarText.text = playerHealthSO.currentValue + " / " + playerHealthSO.maxValue;
    }

    void UpdateMagicBar()
    {
        magicBarImage.fillAmount = ((float)playerMagicSO.currentValue / playerMagicSO.maxValue);
        magicBarText.text = playerMagicSO.currentValue + " / " + playerMagicSO.maxValue;
    }
}