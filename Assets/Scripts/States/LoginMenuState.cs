public class LoginMenuState : State
{
    public LoginMenuState(GameManager gameManager) : base(StateType.LoginMenu, gameManager)
    {

    }
    public override void Enter()
    {
        base.Enter();
        _gameManager.GameTimeScaleControl(false);
        _gameManager.UIManager.MainUI.MainMenuSetActive(false);
        _gameManager.UIManager.InfoPanelSetActive(false);
        _gameManager.UIManager.LoginUI.Initialize();
    }

    public override void Update()
    {
        base.Update();

        if (_gameManager.LoggedIn && _gameManager.CatalogLoaded)
        {
            _stateManager.ChangeState(StateType.MainMenu);
        }
    }

    public override void Exit()
    {
        base.Exit();
        _gameManager.UIManager.MainUI.Initialize();
    }

}
