using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; 

public class ClickedUpgrade : MonoBehaviour
{
    public float clickRange = 3.0f; 
    private Transform playerTransform;
    private Camera mainCamera;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            CheckForClick();
        }
    }

    private void CheckForClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform == transform) 
            {
                float distance = Vector3.Distance(playerTransform.position, transform.position);
                if (distance <= clickRange)
                {
                    SceneManager.LoadScene("Upgrade");
                }
            }
        }
    }
}