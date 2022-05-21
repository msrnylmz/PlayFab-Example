using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    #region PublicFields
    public UIManager UIManager;

    public GameObject LeaderboardRow;
    public Transform LeaderboardContent;
    public GameObject LeaderboardPanel;

    #endregion PublicFields

    #region Methods

    public void ShowLeaderboard()
    {
        UIManager.PlayFabManager.PlayFabLeaderboard.GetLeaderboard();
    }

    public void ContentHide()
    {
        UIManager.ContentHide(LeaderboardContent);
    }

    #endregion Methods
}
