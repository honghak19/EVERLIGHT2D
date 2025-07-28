using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource footstepAudio;
    public AudioSource attackAudio;

    private bool isWalkingSoundPlaying = false;

    void Update()
    {
        // Tấn công bằng phím F
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (attackAudio != null)
                attackAudio.Play();
        }

        // Phát tiếng khi bấm phím di chuyển
        if (IsMovingInputPressed())
        {
            if (footstepAudio != null && !isWalkingSoundPlaying)
            {
                footstepAudio.Play();
                isWalkingSoundPlaying = true;
            }
        }
        else
        {
            if (footstepAudio != null && isWalkingSoundPlaying)
            {
                footstepAudio.Stop();
                isWalkingSoundPlaying = false;
            }
        }
    }

    bool IsMovingInputPressed()
    {
        return Input.GetKey(KeyCode.W) ||
               Input.GetKey(KeyCode.A) ||
               Input.GetKey(KeyCode.S) ||
               Input.GetKey(KeyCode.D) ||
               Input.GetKey(KeyCode.UpArrow) ||
               Input.GetKey(KeyCode.DownArrow) ||
               Input.GetKey(KeyCode.LeftArrow) ||
               Input.GetKey(KeyCode.RightArrow);
    }
}
