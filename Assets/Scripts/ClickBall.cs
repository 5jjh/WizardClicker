using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro; 

public class ClickBall : MonoBehaviour
{
    public AudioClip clickSound; 
    public AudioSource audioSource; 
    public Button clickBall;  
    private bool inputEnabled = false;
    public GameObject clickEffectPrefab;
    public RectTransform popupParent;
    public GameObject PlusOne;
    private void Start()
    {
        if (clickBall != null)
        {
            clickBall.onClick.AddListener(OnButtonClicked);
        }
        Invoke(nameof(EnableInput), 0.2f);
    }

    private void EnableInput()
    {
        inputEnabled = true;
    }
    private void OnButtonClicked()
    {
        if (!inputEnabled)
            return; 

        int manaPerClick = Mathf.RoundToInt(1 * PlayerUpgrades.Instance.clickBoostMultiplier * PlayerUpgrades.Instance.bookMultiplier);
        ManaManager.Instance.AddMana(manaPerClick);

        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound); 
        }

        if (clickEffectPrefab != null)
        {
            Vector3 effectPosition = clickBall.transform.position;
            Instantiate(clickEffectPrefab, effectPosition, Quaternion.identity);
        }


        if (PlusOne != null && popupParent != null)
        {
            GameObject popup = Instantiate(PlusOne, popupParent);
            RectTransform popupRect = popup.GetComponent<RectTransform>();
            popupRect.anchoredPosition = Vector2.zero;
            popupRect.localScale = Vector3.one;
            
            TextMeshProUGUI popupText = popup.GetComponentInChildren<TextMeshProUGUI>();
            if (popupText != null)
            {
                popupText.text = "+" + manaPerClick;
            }
            StartCoroutine(AnimatePopup(popup));
        }
    }

        private IEnumerator AnimatePopup(GameObject popup)
        {
            float duration = 1f;
            float startTime = Time.time;
            RectTransform popupRect = popup.GetComponent<RectTransform>();
            Vector2 startPosition = popupRect.anchoredPosition;
            Vector2 targetPosition = startPosition + Vector2.up * 150f;
            TextMeshProUGUI text = popup.GetComponentInChildren<TextMeshProUGUI>();
            Color startColor = text.color;
            Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);

            while (Time.time < startTime + duration)
            {
                float t = (Time.time - startTime) / duration;
                popupRect.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, t);
                text.color = Color.Lerp(startColor, endColor, t);
                yield return null;
            }

            Destroy(popup);
        }
}