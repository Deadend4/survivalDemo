using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class CraftUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text CraftAttentionText;
    [SerializeField] GameObject CraftWindow;
    [Header("Keyboards")]
    [SerializeField] KeyCode CraftButton;
    [Header("Prefabs")]
    [SerializeField] GameObject CampfirePrefab;
    [Header("Scripts")]
    [SerializeField] StarterAssetsInputs saInput;
    [SerializeField] RaycastItemAligner raycastItemAligner;
    [SerializeField] Torchlight torchlight;
    [SerializeField] SavedData savedData;
    private Inventory inventory;
    void Start()
    {
        CraftWindow.SetActive(false);
        inventory = GetComponent<Inventory>();
    }
    void Update()
    {
        if (Input.GetKeyDown(CraftButton))
        {
            ShowHideWindow();
        }


    }

    public void ShowHideWindow()
    {
        saInput.look = Vector2.zero;
        CraftWindow.SetActive(!CraftWindow.activeSelf);
        saInput.cursorInputForLook = !saInput.cursorInputForLook;
        saInput.cursorLocked = !saInput.cursorLocked;
        saInput.SetCursorState(saInput.cursorLocked);
    }

    public void SpawnCampfire()
    {
        if (inventory.GetAmountItem(0) > 3)
        {
            inventory.DeleteItems(inventory.GetItemByID(0), 4);
            ShowHideWindow();
            raycastItemAligner.PositionRaycast(CampfirePrefab, "Костер");
        }
        else
        {
            InvokeAttention("Для создания костра не хватает ресурсов!");
        }
    }

    public void createTorch()
    {
        if (inventory.GetAmountItem(0) > 0 && inventory.GetAmountItem(3) > 0 && inventory.GetAmountItem(4) > 0)
        {
            inventory.DeleteItems(inventory.GetItemByID(0), 1);
            inventory.DeleteItems(inventory.GetItemByID(3), 1);
            inventory.DeleteItems(inventory.GetItemByID(4), 1);
            if (savedData.torchLife == 0)
            {
                savedData.torchLife = 60;
            }
            savedData.torchCount++;
            torchlight.UpdateCount();
        }
        else
        {
            InvokeAttention("Для создания факела не хватает ресурсов!");
        }
    }

    private void InvokeAttention(string attentionText)
    {
        if (IsInvoking(nameof(hideText)))
            CancelInvoke(nameof(hideText));
        CraftAttentionText.text = attentionText;
        Invoke(nameof(hideText), 2f);
    }

    private void hideText()
    {
        CraftAttentionText.text = "";
    }
}
