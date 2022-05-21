using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region PublicFields
    public UIManager UIManager;
    public Transform InventoryContent;
    public GameObject InventoryItemButtonPrefab;
    #endregion PublicFields

    #region Methods
    public void ContentHide()
    {
        UIManager.ContentHide(InventoryContent);
        UIManager.PlayFabManager.PlayFabInventoryManager.InventoryItems.Clear();
    }
    #endregion Methods
}
