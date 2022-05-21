public class MainMenuState : State
{
    public MainMenuState(GameManager gameManager) : base(StateType.MainMenu, gameManager)
    {

    }
    public override void Enter()
    {
        _gameManager.UIManager.InfoPanelSetActive(true);
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
