using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    public static PlayerUpgrades Instance;
    public int autoClickerLevel = 0;
    public int clickBoostLevel = 0;
    public int bookLevel = 0;

    public float autoClickerRate = 1f;  
    public float clickBoostMultiplier = 1f; 
    public float bookMultiplier = 1f;  
    private float autoClickTimer = 0f;
    public int autoClickerCost = 100;
    public int clickBoostCost = 150;
    public int bookCost = 500;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
        LoadPlayerProgress();
    }

    private void Update()
    {
        AutoClickerUpdate();
    }

    private void AutoClickerUpdate()
    {
        if (autoClickerLevel > 0)
        {
            autoClickTimer += Time.deltaTime;
            if (autoClickTimer >= 1f)
            {
                int manaGained = Mathf.RoundToInt(autoClickerRate * bookMultiplier);
                ManaManager.Instance.AddMana(manaGained);
                autoClickTimer = 0f;
            }
        }
    }

    public void UpgradeAutoClicker()
    {
        autoClickerLevel++;
        autoClickerRate += 1f; 
        SavePlayerProgress();
    }

    public void UpgradeClickBoost()
    {
        clickBoostLevel++;
        clickBoostMultiplier *= 1.1f; 
        SavePlayerProgress();
    }

    public static event System.Action OnBookUpgrade;
    public void UpgradeBook()
    {
        bookLevel++;
        bookMultiplier *= 1.2f; 
        SavePlayerProgress();
        OnBookUpgrade?.Invoke();
    }

    public void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("AutoClickerLevel", autoClickerLevel);
        PlayerPrefs.SetInt("ClickBoostLevel", clickBoostLevel);
        PlayerPrefs.SetInt("BookLevel", bookLevel);
        PlayerPrefs.SetFloat("AutoClickerRate", autoClickerRate);
        PlayerPrefs.SetFloat("ClickBoostMultiplier", clickBoostMultiplier);
        PlayerPrefs.SetFloat("BookMultiplier", bookMultiplier);
        PlayerPrefs.SetInt("AutoClickerCost", autoClickerCost);
        PlayerPrefs.SetInt("ClickBoostCost", clickBoostCost);
        PlayerPrefs.SetInt("BookCost", bookCost);
        PlayerPrefs.Save();
    }

    private void LoadPlayerProgress()
    {
        autoClickerLevel = PlayerPrefs.GetInt("AutoClickerLevel", 0);
        clickBoostLevel = PlayerPrefs.GetInt("ClickBoostLevel", 0);
        bookLevel = PlayerPrefs.GetInt("BookLevel", 0);
        autoClickerRate = PlayerPrefs.GetFloat("AutoClickerRate", 1f);
        clickBoostMultiplier = PlayerPrefs.GetFloat("ClickBoostMultiplier", 1f);
        bookMultiplier = PlayerPrefs.GetFloat("BookMultiplier", 1f);
        autoClickerCost = PlayerPrefs.GetInt("AutoClickerCost", 100);
        clickBoostCost = PlayerPrefs.GetInt("ClickBoostCost", 150);
        bookCost = PlayerPrefs.GetInt("BookCost", 500);
    }
}