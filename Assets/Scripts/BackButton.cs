using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Button backButton;  
    private void Start()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
    }
    private void OnBackButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
}