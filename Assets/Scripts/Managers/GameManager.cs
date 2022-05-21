using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region PublicFields
    public PlayFabManager PlayFabManager;
    public StateManager GameStateManager;
    public UIManager UIManager;
    public PlayerShooting PlayerShooting;
    public PlayerController PlayerController;
    public EnemyController EnemyController;
    public PlayerMovement PlayerMovement;

    public bool LoggedIn;
    public bool CatalogLoaded;
    public bool GameOver;

    public int GameTime;
    public float RemainingTime;
    public int Gold;

    #endregion PublicFields

    #region UnityMethods
    void Start()
    {
        Initialize();
    }
    void Update()
    {
        Controller();
    }
    #endregion UnityMethods

    #region Methods
    private void Initialize()
    {
        InitializeGameStates();
        GameStateManager.StartState(State.StateType.LoginMenu);
    }

    public void GamePlayInitialize()
    {
        GameTime = 30;
        RemainingTime = GameTime;
        UIManager.GamePlayUIInitialize();
        GameTimeScaleControl(true);
        PlayerShooting.Initialize();
        EnemyController.Initialize();
    }

    public void ResetGame()
    {
        RemainingTime = GameTime;
        GameOver = false;
        EnemyController.Reset();
        PlayerController.EnemyDestroyCount = 0;
        PlayerController.gameObject.transform.position = new Vector2(0, 0);
        UIManager.GamePlayUI.KillCountText.text = "0";
        UIManager.GamePlayUI.RemainingTimeText.text = "0";
    }
    private void InitializeGameStates()
    {
        GameStateManager = new StateManager();
        GameStateManager.AddState(new LoginMenuState(this));
        GameStateManager.AddState(new MainMenuState(this));
        GameStateManager.AddState(new InventoryState(this));
        GameStateManager.AddState(new ShopState(this));
        GameStateManager.AddState(new LeaderboardState(this));
        GameStateManager.AddState(new GamePlayState(this));
        GameStateManager.AddState(new GameOverState(this));
    }
    public void GameOverControl()
    {
        RemainingTime -= Time.deltaTime;
        if (0 > RemainingTime)
        {
            GameOver = true;
        }
    }

    private void Controller()
    {
        GameStateManager.UpdateController();
    }

    public void GameTimeScaleControl(bool control)
    {
        if (control)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    #endregion Methods
}
