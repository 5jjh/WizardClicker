using TMPro;
using UnityEngine;
using System.Collections;
public class ManaDisplay : MonoBehaviour
{
    public TextMeshProUGUI manaText;

    void Start()
    {
        if (manaText == null)
            manaText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(WaitForManaManager());
    }

    
    IEnumerator WaitForManaManager()
    {
        while (ManaManager.Instance == null)
            yield return null;

        UpdateDisplay(); 
    }

    void Update()
    {
        UpdateDisplay(); 
    }

    void UpdateDisplay()
    {
        manaText.text = "Mana: " + ManaManager.Instance.Mana.ToString();
    }
}