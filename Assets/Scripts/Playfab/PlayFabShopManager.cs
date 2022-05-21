using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabShopManager : MonoBehaviour
{
    #region PublicFields
    public UIManager UIManager;
    public PlayFabManager PlayFabManager;
    public List<ShopItem> ShopItems;
    #endregion PublicFields


    #region Shop

    public void Initialize()
    {
        GetShopItems();
    }
    private void CreateShopButtons()
    {
        foreach (ShopItem item in ShopItems)
        {
            GameObject itemButton = Instantiate(UIManager.ShopUI.ShopItemButtonPrefab,
                UIManager.ShopUI.ShopContent.position,
                Quaternion.identity,
                UIManager.ShopUI.ShopContent.transform);
            ShopItemButtonUIElements uiElements = itemButton.GetComponent<ShopItemButtonUIElements>();
            if (uiElements != null)
            {
                uiElements.CostText.text = item.Cost.ToString();
                uiElements.ItemNameText.text = item.Name;
                PlayFabManager.PlayFabCatalog.SetItemImage(item.Name, uiElements.ItemImage);

                uiElements.gameObject.GetComponent<Button>().onClick.AddListener(() =>
                {
                    MakePurchase(item.Name, item.Cost);
                });
            }
        }
    }

    private void MakePurchase(string name, int price)
    {
        PurchaseItemRequest request = new PurchaseItemRequest();
        request.CatalogVersion = "Guns";
        request.StoreId = "PlayerGuns";
        request.VirtualCurrency = "GD";
        request.Price = price;
        request.ItemId = name;

        PlayFabClientAPI.PurchaseItem(request, MakePurchaseResult, OnError);
    }


    private void MakePurchaseResult(PurchaseItemResult result)
    {
        PlayFabManager.PlayFabInventoryManager.GetGold();
    }

    private void GetShopItems()
    {
        GetStoreItemsRequest request = new GetStoreItemsRequest();
        request.CatalogVersion = "Guns";
        request.StoreId = "PlayerGuns";
        PlayFabClientAPI.GetStoreItems(request, GetShopItemsPricesResult, OnError);
    }
    private void GetShopItemsPricesResult(GetStoreItemsResult result)
    {
        foreach (StoreItem storeItem in result.Store)
        {
            ShopItem item = new ShopItem()
            {
                Name = storeItem.ItemId,
                Cost = (int)storeItem.VirtualCurrencyPrices["GD"],
            };
            ShopItems.Add(item);
        }
        CreateShopButtons();
    }
    private void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion Shop

}
