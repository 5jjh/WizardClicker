using UnityEngine;
using TMPro;
public class ClickerManager : MonoBehaviour
{
    public TextMeshProUGUI totalBoostText;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        float totalBoost = PlayerPrefs.GetFloat("TotalBoost", 1f);
        totalBoostText.text = "Total Boost: " + Mathf.RoundToInt(totalBoost * 100) / 100f + "x";
    }
}