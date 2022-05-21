using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayFabCatalog : MonoBehaviour
{
    public GameManager GameManager;

    #region Fields
    private Dictionary<string, string> _URLsOfItemImages = new Dictionary<string, string>();
    #endregion Fields

    #region GetCatalog
    public void GetCatalogItems()
    {
        GetCatalogItemsRequest request = new GetCatalogItemsRequest();
        request.CatalogVersion = "Guns";
        PlayFabClientAPI.GetCatalogItems(request, GetCatalogItemsResult, OnError);
    }

    private void GetCatalogItemsResult(GetCatalogItemsResult result)
    {
        foreach (CatalogItem item in result.Catalog)
        {
            if (!_URLsOfItemImages.ContainsKey(item.ItemId))
            {
                _URLsOfItemImages.Add(item.ItemId, item.ItemImageUrl);
            }
        }

        GameManager.CatalogLoaded = true;
    }
    private void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion GetCatalog

    #region SetItemImage
    // add images of items
    public void SetItemImage(string name, RawImage image)
    {
        if (_URLsOfItemImages.ContainsKey(name))
        {
            StartCoroutine(GetTexture(_URLsOfItemImages[name], image));
        }
        else
        {
            Debug.LogWarning("key not found");
        }
    }
    // download  images of items
    IEnumerator GetTexture(string url, RawImage item)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        Texture2D itemTexture = DownloadHandlerTexture.GetContent(www);
        item.texture = itemTexture;
    }
    #endregion SetItemImage


}
