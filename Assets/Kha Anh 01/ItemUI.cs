using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerClickHandler
{
    public Sprite itemIcon;
    [TextArea] public string itemDescription;

    public void OnPointerClick(PointerEventData eventData)
    {
        InventoryDisplay display = Object.FindFirstObjectByType<InventoryDisplay>();

        display.ShowItemInfo(itemIcon, itemDescription);
    }
}