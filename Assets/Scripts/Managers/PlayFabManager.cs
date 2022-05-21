using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabManager : MonoBehaviour
{
    #region PublicFields
    public UIManager UIManager;
    public GameManager GameManager;
    public PlayFabShopManager PlayFabShopManager;
    public PlayFabInventoryManager PlayFabInventoryManager;
    public PlayFabStatistics PlayFabStatistics;
    public PlayFabLeaderboard PlayFabLeaderboard;
    public PlayFabCatalog PlayFabCatalog;

    #endregion PublicFields

    #region Properties
    public string PlayFabId { get; private set; }
    #endregion Properties


    #region LoginRegister

    public void Register()
    {
        if (UIManager.LoginUI.PasswordInput.text.Length < 6)
        {
            UIManager.LoginUI.MessageText.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = UIManager.LoginUI.EmailInput.text,
            Password = UIManager.LoginUI.PasswordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        GameManager.PlayFabManager.PlayFabStatistics.SetStats();
        UIManager.LoginUI.MessageText.text = "Registered!";
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = UIManager.LoginUI.EmailInput.text,
            Password = UIManager.LoginUI.PasswordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    private void OnLoginSuccess(LoginResult result)
    {
        GameManager.LoggedIn = true;

        Debug.Log("Logged in!");
        PlayFabId = result.PlayFabId;
        UIManager.LoginUI.MessageText.text = "Logged in !";
        UIManager.ShowID(PlayFabId);
        PlayFabCatalog.GetCatalogItems();
        PlayFabStatistics.GetStatistics();
        PlayFabInventoryManager.GetGold();
    }

    private void OnError(PlayFabError error)
    {
        UIManager.LoginUI.MessageText.text = error.ErrorMessage;
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion LoginRegister
}
