using UnityEngine;
using TMPro; 

public class UpgradeShop : MonoBehaviour
{
    public TextMeshProUGUI autoClickerCostText;
    public TextMeshProUGUI clickBoostCostText;
    public TextMeshProUGUI bookCostText;
    public TextMeshProUGUI combinedBoostText;
    private bool inputEnabled = false;
    private void Start()
    {
        UpdateCostTexts();
        Invoke(nameof(EnableInput), 0.2f);
    }

    private void EnableInput()
    {
        inputEnabled = true;
    }

    public void BuyAutoClicker()
    {
        int currentAutoCost = PlayerUpgrades.Instance.autoClickerCost;
        if (!inputEnabled)
            return;

        if (ManaManager.Instance.Mana >= currentAutoCost)
        {
            ManaManager.Instance.SpendMana(currentAutoCost);
            PlayerUpgrades.Instance.UpgradeAutoClicker();
            PlayerUpgrades.Instance.autoClickerCost = Mathf.RoundToInt(currentAutoCost * 1.25f);
            UpdateCostTexts();
        }
    }

    public void BuyClickBoost()
    {
        int currentClickCost = PlayerUpgrades.Instance.clickBoostCost;
        if (!inputEnabled)
            return;
        if (ManaManager.Instance.Mana >= currentClickCost)
        {
            ManaManager.Instance.SpendMana(currentClickCost);
            PlayerUpgrades.Instance.UpgradeClickBoost();
            PlayerUpgrades.Instance.clickBoostCost = Mathf.RoundToInt(currentClickCost * 1.25f);
            UpdateCostTexts();
        }
    }

    public void BuyBook()
    {
        int currentBookCost = PlayerUpgrades.Instance.bookCost;
        if (!inputEnabled)
            return;
        if (ManaManager.Instance.Mana >= currentBookCost)
        {
            ManaManager.Instance.SpendMana(currentBookCost);
            PlayerUpgrades.Instance.UpgradeBook();
            PlayerUpgrades.Instance.bookCost = Mathf.RoundToInt(currentBookCost * 1.5f);
            UpdateCostTexts();
        }
    }

    private void UpdateCostTexts()
    {
        autoClickerCostText.text = "Cost: " + PlayerUpgrades.Instance.autoClickerCost + " Current Level: " + PlayerUpgrades.Instance.autoClickerLevel;
        clickBoostCostText.text = "Cost: " + PlayerUpgrades.Instance.clickBoostCost + " Current Level: " + PlayerUpgrades.Instance.clickBoostLevel;
        bookCostText.text = "Cost: " + PlayerUpgrades.Instance.bookCost + " Current Level: " + PlayerUpgrades.Instance.bookLevel;

        float totalBoost = 1f; 
        totalBoost *= 1 + PlayerUpgrades.Instance.clickBoostLevel * 0.1f;  
        totalBoost *= 1 + PlayerUpgrades.Instance.bookLevel * 0.2f; 
        PlayerPrefs.SetFloat("TotalBoost", totalBoost);
        PlayerPrefs.Save();
        combinedBoostText.text = "Total Boost: " + Mathf.RoundToInt(totalBoost * 100) / 100f + "x";
    }
}