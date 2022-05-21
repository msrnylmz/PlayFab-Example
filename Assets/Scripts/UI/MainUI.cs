using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    #region PublicFields
    public UIManager UIManager;

    public Button MainMenu;
    public Button StartGame;
    public Button ShowInventory;
    public Button ShowShop;

    public Button Leaderboard;

    #endregion PublicFields

    #region Fields
    private GameManager _gameManager;
    #endregion Fields

    #region Methods


    public void Initialize()
    {
        _gameManager = UIManager.GameManager;
        ShowInventory.onClick.AddListener(() => _gameManager.GameStateManager.ChangeState(State.StateType.Inventory));
        ShowShop.onClick.AddListener(() => _gameManager.GameStateManager.ChangeState(State.StateType.Shop));
        StartGame.onClick.AddListener(() => _gameManager.GameStateManager.ChangeState(State.StateType.GamePlay));
        MainMenu.onClick.AddListener(() => _gameManager.GameStateManager.ChangeState(State.StateType.MainMenu));
        Leaderboard.onClick.AddListener(() =>_gameManager.GameStateManager.ChangeState(State.StateType.Leaderboard));
        MainMenuSetActive(true);
    }
    public void MainMenuSetActive(bool control)
    {
        MainMenu.gameObject.SetActive(control);
    }

    #endregion Methods

}
