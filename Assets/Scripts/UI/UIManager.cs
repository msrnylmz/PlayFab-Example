using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region PublicFields
    public PlayFabManager PlayFabManager;
    public GameManager GameManager;

    [Header("General UI")]
    public Text PlayFabIdText;
    public Text XPText;
    public Text GoldText;
    public Panel CurrentPanel;
    public List<Panel> StatePanels;

    public GameObject BackGround;
    public GameObject InfoPanel;

    public LoginUI LoginUI;
    public MainUI MainUI;
    public LeaderboardUI LeaderboardUI;
    public ShopUI ShopUI;
    public InventoryUI InventoryUI;
    public GameOverUI GameOverUI;
    public GamePlayUI GamePlayUI;

    #endregion PublicFields

    #region Methods
    // All panel control
    public void ChangePanel(State.StateType currentStateEnum)
    {
        if (CurrentPanel != null)
        {
            CurrentPanel.gameObject.SetActive(false);
        }
        for (int i = 0; i < StatePanels.Count; i++)
        {
            if (StatePanels[i].StatePanel == currentStateEnum)
            {
                CurrentPanel = StatePanels[i];
                CurrentPanel.gameObject.SetActive(true);
            }
        }
    }

    public void InfoPanelSetActive(bool control)
    {
        InfoPanel.gameObject.SetActive(control);
    }
    public void CurrentPanelSetActive(bool control)
    {
        CurrentPanel.gameObject.SetActive(control);
    }
    public void BackgroundSetActive(bool control)
    {
        BackGround.gameObject.SetActive(control);
    }
    public void ContentHide(Transform content)
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }
    }
    public void GamePlayUIInitialize()
    {
        BackgroundSetActive(false);
    }

    public void ShowGold()
    {
        GoldText.text = GameManager.Gold.ToString();
    }
    public void ShowXP()
    {
        XPText.text = GameManager.PlayerController.PlayerXP.ToString();
    }
    public void ShowID(string id)
    {
        PlayFabIdText.text = id;
    }
    #endregion Methods
}
