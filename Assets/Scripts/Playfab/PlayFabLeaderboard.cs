using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLeaderboard : MonoBehaviour
{
    #region PublicFields
    public UIManager UIManager;
    #endregion PublicFields


    #region Leaderboard

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "XP",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboard, OnError);
    }
    private void OnGetLeaderboard(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            GameObject cloneRow = Instantiate(UIManager.LeaderboardUI.LeaderboardRow,
                  UIManager.LeaderboardUI.LeaderboardContent.position,
                  Quaternion.identity, UIManager.LeaderboardUI.LeaderboardContent);

            LeaderboardUIElements uiElements = cloneRow.GetComponent<LeaderboardUIElements>();
            if(uiElements != null)
            {
                uiElements.PlayFabID.text = item.PlayFabId;
                uiElements.PlayerXP.text = item.StatValue.ToString();
            }
        }
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion Leaderboard
}
