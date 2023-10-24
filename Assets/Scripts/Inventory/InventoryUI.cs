using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private List<Image> icons = new List<Image>();
    [SerializeField] private List<TMP_Text> amounts = new List<TMP_Text>();
    public void UpdateUI(Inventory inventory)
    {

        for (int i = 0; i < inventory.GetSize() && i < icons.Count; i++)
        {
            if (inventory.GetItem(i) != null)
            {
                icons[i].color = new Color(1, 1, 1, 1);
                icons[i].sprite = inventory.GetItem(i).icon;
                amounts[i].text = inventory.GetAmount(i) > 1 ? inventory.GetAmount(i).ToString() : "";
            }
            else
            {
                icons[i].color = new Color(1, 1, 1, 0);
                icons[i].sprite = null;
                amounts[i].text = "";
            }

        }
        for (int i = inventory.GetSize(); i < icons.Count; i++)
        {
            icons[i].color = new Color(1, 1, 1, 0);
            icons[i].sprite = null;
            amounts[i].text = "";
        }
    }
}
