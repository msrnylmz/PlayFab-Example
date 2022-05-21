using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabInventoryManager : MonoBehaviour
{

    #region PublicFields
    public UIManager UIManager;
    public PlayFabManager PlayFabManager;
    public List<InventoryItem> InventoryItems;
    #endregion PublicFields


    #region Inventory

    public void Initialize()
    {
        GetInventory();
    }

    private void CreateInventoryButtons()
    {
        foreach (InventoryItem item in InventoryItems)
        {
            GameObject itemButton = Instantiate(UIManager.InventoryUI.InventoryItemButtonPrefab,
                UIManager.InventoryUI.InventoryContent.position,
                Quaternion.identity,
                UIManager.InventoryUI.InventoryContent);
            InventoryItemButtonUIElements uiElements = itemButton.GetComponent<InventoryItemButtonUIElements>();
            if (uiElements != null)
            {
                uiElements.ItemNameText.text = item.Name;
                uiElements.RemainingUsesText.text = item.RemainingUses.ToString() + "x";

                PlayFabManager.PlayFabCatalog.SetItemImage(item.Name, uiElements.ItemImage);
                uiElements.gameObject.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Debug.Log("Selected");
                });
            }
        }
    }

    private void GetInventory()
    {
        GetUserInventoryRequest request = new GetUserInventoryRequest();

        PlayFabClientAPI.GetUserInventory(request, GetInventoryResult, OnError);
    }

    private void GetInventoryResult(GetUserInventoryResult result)
    {
        foreach (ItemInstance itemInventory in result.Inventory)
        {
            InventoryItem item = new InventoryItem()
            {
                Name = itemInventory.ItemId,
                RemainingUses = (int)itemInventory.RemainingUses
            };
            InventoryItems.Add(item);
        }
        CreateInventoryButtons();
    }

    public void GetGold()
    {
        GetUserInventoryRequest request = new GetUserInventoryRequest();
        PlayFabClientAPI.GetUserInventory(request, GelGoldResult, OnError);
    }

    private void GelGoldResult(GetUserInventoryResult result)
    {
        UIManager.GameManager.Gold = result.VirtualCurrency["GD"];
        UIManager.ShowGold();
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion Inventory
}
