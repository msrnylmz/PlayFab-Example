using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    public UIManager UIManager;

    public Text KillCountText;
    public Text RemainingTimeText;

    public void ShowKillCount(int count)
    {
        KillCountText.text = count.ToString();
    }

    public void ShowRemainingTime()
    {
        RemainingTimeText.text = ((int)UIManager.GameManager.RemainingTime).ToString();
    }
}
