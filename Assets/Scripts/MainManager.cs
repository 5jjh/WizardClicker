using UnityEngine;
using UnityEditor;
using TMPro;
public class MainManager : MonoBehaviour
{
    private Transform playerTransform;
    public TextMeshProUGUI totalBoostText;


    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        float totalBoost = PlayerPrefs.GetFloat("TotalBoost", 1f);
        totalBoostText.text = "Total Boost: " + Mathf.RoundToInt(totalBoost * 100) / 100f + "x";
    }
}
