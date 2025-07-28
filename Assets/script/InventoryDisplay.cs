using UnityEngine;
using UnityEngine.UI;
using TMPro; // Nếu bạn dùng TextMeshPro

public class InventoryDisplay : MonoBehaviour
{
    public Image previewImage;
    public TextMeshProUGUI descriptionText;

    public void ShowItemInfo(Sprite icon, string description)
    {
        previewImage.sprite = icon;
        descriptionText.text = description;
    }
}
