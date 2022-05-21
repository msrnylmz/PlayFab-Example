public class GamePlayState : State
{
    public GamePlayState(GameManager gameManager) : base(StateType.GamePlay, gameManager)
    {

    }
    public override void Enter()
    {
        base.Enter();
        _gameManager.UIManager.MainUI.MainMenuSetActive(false);
        _gameManager.GamePlayInitialize();
    }

    public override void Update()
    {
        base.Update();
        _gameManager.GameOverControl();
        _gameManager.PlayerMovement.PlayerSetInput();
        _gameManager.PlayerShooting.Controller();
        _gameManager.UIManager.GamePlayUI.ShowRemainingTime();
        if (_gameManager.GameOver)
        {
            _stateManager.ChangeState(StateType.GameOver);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
