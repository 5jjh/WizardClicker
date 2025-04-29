using UnityEngine;

public class ManaManager : MonoBehaviour
{
    public static ManaManager Instance; 
    public int Mana { get; private set; }

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

        LoadMana();
    }

    public void AddMana(int amount)
    {
        Mana += amount;
        SaveMana();
    }
    

    public void SpendMana(int amount)
    {
        if (Mana >= amount)
        {
            Mana -= amount;
            SaveMana();
        }
    }

    private void SaveMana()
    {
        PlayerPrefs.SetInt("Mana", Mana);
        PlayerPrefs.Save();
    }

    private void LoadMana()
    {
        Mana = PlayerPrefs.GetInt("Mana", 0);
    }
}
