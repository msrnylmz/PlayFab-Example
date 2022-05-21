using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    #region PublicFields
    public UIManager UIManager;

    public Transform ShopContent;
    public GameObject ShopItemButtonPrefab;
    #endregion PublicFields

    #region Methods
    public void ContentHide()
    {
        UIManager.ContentHide(ShopContent);
        UIManager.PlayFabManager.PlayFabShopManager.ShopItems.Clear();
    }
    #endregion Methods

}
