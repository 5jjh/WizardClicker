using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;

    public AudioSource footstepAudio; 
    public float footstepThreshold = 0.1f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");  
        float z = Input.GetAxis("Vertical");    
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        HandleNoise(move);
    }

    private void HandleNoise(Vector3 move)
    {
        bool isMoving = move.magnitude > footstepThreshold;

        if (isMoving)
        {
            if (!footstepAudio.isPlaying)
                footstepAudio.Play();
        }
        else
        {
            if (footstepAudio.isPlaying)
                footstepAudio.Pause();
        }
    }
}