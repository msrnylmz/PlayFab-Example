public class GameOverState : State
{
    public GameOverState(GameManager gameManager) : base(StateType.GameOver, gameManager)
    {

    }
    public override void Enter()
    {
        _gameManager.PlayFabManager.PlayFabStatistics.StartCloudUpdatePlayerStatistics();
        _gameManager.UIManager.BackgroundSetActive(true);
        _gameManager.UIManager.MainUI.MainMenuSetActive(true);
        _gameManager.UIManager.GameOverUI.Initialize();
        _gameManager.GameTimeScaleControl(false);
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        _gameManager.ResetGame();
        base.Exit();
    }
}
