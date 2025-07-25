using UnityEngine;

public class SwitchObject : MonoBehaviour
{
    public GameObject objectToActivate;
    public void OnButtonClick()
    {
        // Tắt object chứa script này
        gameObject.SetActive(false);

        // Bật object khác
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}