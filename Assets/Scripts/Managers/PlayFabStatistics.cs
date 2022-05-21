using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.PfEditor.Json;

public class PlayFabStatistics : MonoBehaviour
{
    #region PublicFields
    public UIManager UIManager;
    public PlayerController PlayerController;
    #endregion PublicFields


    #region Statistics

    public void GetStatistics()
    {
        GetPlayerStatisticsRequest request = new GetPlayerStatisticsRequest();
        PlayFabClientAPI.GetPlayerStatistics(request, GetStatisticsResult, OnError);
    }

    private void GetStatisticsResult(GetPlayerStatisticsResult result)
    {
        foreach (StatisticValue statistic in result.Statistics)
        {
            switch(statistic.StatisticName)
            {
                case "XP":
                    PlayerController.PlayerXP = statistic.Value;
                    break;
            }
        }
        UIManager.ShowXP();
    }

    // update statistics when registered 
    public void SetStats()
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "XP",
                    Value = 0
                }
            }
        },SetStatsResult,OnError);
    }

    private void SetStatsResult(UpdatePlayerStatisticsResult resul)
    {

    }

    public void StartCloudUpdatePlayerStatistics()
    {
        ExecuteCloudScriptRequest request = new ExecuteCloudScriptRequest();
        request.FunctionName = "UpdatePlayerStats";
        request.FunctionParameter = new { enemyDestroyCount = PlayerController.EnemyDestroyCount };
        request.GeneratePlayStreamEvent = true;
        PlayFabClientAPI.ExecuteCloudScript(request, OnCloudUpdatePlayerStatistics, OnError);
    }

    private void OnCloudUpdatePlayerStatistics(ExecuteCloudScriptResult result)
    {
        GetStatistics();
        Debug.Log(JsonWrapper.SerializeObject(result.FunctionResult));
    }
    private void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion Statistics
}
